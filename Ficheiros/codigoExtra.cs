 [DatabaseGenerated(DatabaseGeneratedOption.None)]
 
 
 
 
 protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			base.OnModelCreating(modelBuilder);
}