﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Multas.Models;

namespace Multas.Controllers
{
    public class AgentesController : Controller
    {
        //cria um objecto privado que 'referência' a BD
        private MultasDb db = new MultasDb();

        // GET: Agentes
        public ActionResult Index()
        {
            // em LINQ : db.Agentes.ToList() --> em sql : select * from Agentes;
            // lista de agentes, presentes na BD
            return View(db.Agentes.ToList());
        }

        // GET: Agentes/Details/5
        /// <summary>
        /// Apresenta numa listagem os dados de um agente
        /// </summary>
        /// <param name="id">identifica o número do agente a pesquisar</param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            // int? id ---> o '?' informa que o parâmetro é de preenchimento facultativo
            //caso não haja ID, nada é feito
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // pesquisa os dados do agente, cujo ID foi fornecido
            Agentes agentes = db.Agentes.Find(id);
            // valida se foi encontrado algum Agente, se não foi encontrado, nada faz
            if (agentes == null)
            {
                return HttpNotFound();
            }
            // apresenta na view os dados do agente
            return View(agentes);
        }

        // GET: Agentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Esquadra")] Agentes agente, //remoção do campo fotografia desta linha
                                   HttpPostedFileBase carregaFotografia)
        {

            // Gerar o ID para o novo agente
            int novoID = 0;
            novoID = db.Agentes.Max(a=>a.ID)+1;
            agente.ID = novoID;   // atribuir o ID deste Agente

            // variável auxiliar
            string nomeFicheiro = "Agente_" + novoID + ".jpg";
            string caminho = "";
            /// primeiro que tudo, há que garantir que a imagem existe
            if (carregaFotografia != null)
            {
                //a imagem existe
                agente.Fotografia= nomeFicheiro;
                // definir o nome do ficheiro e o sue caminho
                caminho = Path.Combine(Server.MapPath("~/imagens/"), nomeFicheiro);
            }
            else
            {
                // não foi submetida uma imagem


                //gerar mensagem de erro para elucidar o utilizador do erro
                ModelState.AddModelError("","Não foi inserida uma imagem.");

                // redirecionar o utilizador para a view, para que ele corrija os dados
                return View(agente);
            }
            /// formatar o tamanho da imagem ---> fazer em casa
            /// será que o ficheiro é uma imagem ---> fazer em casa
            /// guardar a imagem no disco do servidor


            // ModelState.IsValid --> confronta os dados recebidos como o modelo,
            // para verificar se o que recebeu é o que deveria ter sido recebido
            if (ModelState.IsValid)
            {
                // adiciona o Agente à estrutura de dados
                db.Agentes.Add(agente);
                // efectuam um commit à BD
                db.SaveChanges();
                // guardar o ficheiro no disco rígido
                carregaFotografia.SaveAs(caminho);
                // redirecciona o utilizador para a página do inicio
                return RedirectToAction("Index");
            }
            // se aqui chegou, é pq aalguma coisa correu mal...
            // devolvo os dados do agente à view
            return View(agente);
        }

        // GET: Agentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }

        // POST: Agentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Fotografia,Esquadra")] Agentes agentes)
        {
            if (ModelState.IsValid)
            {
                // update
                db.Entry(agentes).State = EntityState.Modified;
                // commit
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agentes);
        }

        // GET: Agentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }

        // POST: Agentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteNewMethod(int id)
        {
            Agentes agentes = db.Agentes.Find(id);
            db.Agentes.Remove(agentes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
