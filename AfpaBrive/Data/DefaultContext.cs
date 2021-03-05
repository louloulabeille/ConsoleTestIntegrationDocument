using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AfpaBrive;
using ModelAfpa;

#nullable disable

namespace DefautAfpaBriveContext
{
    public partial class DefaultContext : DbContext
    {
        public DefaultContext()
        {
        }

        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entreprise> Entreprises { get; set; }
        public virtual DbSet<Etablissement> Etablissements { get; set; }
        public virtual DbSet<OffreFormation> OffreFormations { get; set; }
        public virtual DbSet<Pee> Pees { get; set; }
        public virtual DbSet<PeriodePee> PeriodePees { get; set; }
        public virtual DbSet<Personne> Personnes { get; set; }
        public virtual DbSet<ProduitDeFormation> ProduitDeFormations { get; set; }
        public virtual DbSet<StagiaireOffreFormation> StagiaireOffreFormations { get; set; }
        public virtual DbSet<Stagiaire> Stagiaires { get; set; }
        public virtual DbSet<Tiers> Tiers { get; set; }
        public virtual DbSet<CollaborateurAfpa> CollaborateurAfpas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=AFPA_2020;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<Entreprise>(entity =>
            {
                entity.HasKey(e => e.IdEntreprise);

                entity.ToTable("Entreprise");

                entity.Property(e => e.CodePostalEntreprise)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ComplementAdresseEntreprise)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ComplementIdentificationEntreprise)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroNomVoieEntreprise)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroSiret)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("NumeroSIRET")
                    .IsFixedLength(true);

                entity.Property(e => e.RaisonSociale)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VilleEntreprise)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Etablissement>(entity =>
            {
                entity.HasKey(e => e.IdEtablissement)
                    .HasName("PK_Etablissement_1");

                entity.ToTable("Etablissement");

                entity.Property(e => e.IdEtablissement)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CodePostalEtablissement)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ComplementAdresseEtablissement)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ComplementIdentificationEtablissement)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DesignationEtablissement)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdEtablissementRattachement)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NumeroNomVoieEtablissement)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VilleEtablissement)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEtablissementRattachementNavigation)
                    .WithMany(p => p.InverseIdEtablissementRattachementNavigation)
                    .HasForeignKey(d => d.IdEtablissementRattachement)
                    .HasConstraintName("FK_Etablissement_Etablissement");
            });

            modelBuilder.Entity<OffreFormation>(entity =>
            {
                entity.HasKey(e => new { e.IdOffreFormation, e.IdEtablissement });

                entity.ToTable("OffreFormation");

                entity.Property(e => e.IdEtablissement)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateDebutOffreFormation).HasColumnType("date");

                entity.Property(e => e.DateFinOffreFormation).HasColumnType("date");

                entity.Property(e => e.IdProduitFormation)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdEtablissementNavigation)
                    .WithMany(p => p.OffreFormations)
                    .HasForeignKey(d => d.IdEtablissement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OffreFormation_Etablissement");

                //entity.HasOne(d => d.IdPersonneNavigation)
                //    .WithMany(p => p.OffreFormations)
                //    .HasForeignKey(d => d.IdPersonne)
                //    .HasConstraintName("FK_OffreFormation_Formateur");

                entity.HasOne(d => d.IdProduitFormationNavigation)
                    .WithMany(p => p.OffreFormations)
                    .HasForeignKey(d => d.IdProduitFormation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OffreFormation_ProduitDeFormation");
            });

            modelBuilder.Entity<Pee>(entity =>
            {
                entity.HasKey(e => e.IdPee);

                entity.ToTable("Pee");

                entity.HasOne(d => d.IdEntrepriseNavigation)
                    .WithMany(p => p.Pees)
                    .HasForeignKey(d => d.IdEntreprise)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PEE_Entreprise");

                //entity.HasOne(d => d.IdResponsableJuridiqueNavigation)
                //    .WithMany(p => p.PeeIdResponsableJuridiqueNavigations)
                //    .HasForeignKey(d => d.IdResponsableJuridique)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_PEE_ResponsableJuridique");

                //entity.HasOne(d => d.IdStagiaireNavigation)
                //    .WithMany(p => p.PeeIdStagiaireNavigations)
                //    .HasForeignKey(d => d.IdStagiaire)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Pee_Stagiaire");

                //entity.HasOne(d => d.IdTuteurNavigation)
                //    .WithMany(p => p.PeeIdTuteurNavigations)
                //    .HasForeignKey(d => d.IdTuteur)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_PEE_Tuteur");
            });

            modelBuilder.Entity<PeriodePee>(entity =>
            {
                entity.HasKey(e => new { e.IdPee, e.DateDebutPeriodePee, e.DateFinPeriodePee });

                entity.ToTable("Periode_Pee");

                entity.Property(e => e.DateDebutPeriodePee).HasColumnType("date");

                entity.Property(e => e.DateFinPeriodePee).HasColumnType("date");

                entity.HasOne(d => d.IdPeeNavigation)
                    .WithMany(p => p.PeriodePees)
                    .HasForeignKey(d => d.IdPee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Periode_Pee_Pee");
            });

            modelBuilder.Entity<Personne>(entity =>
            {
                entity.HasKey(e => e.IdPersonne);

                entity.ToTable("Personne");

                entity.Property(e => e.AdresseMail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CatPersonne)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('P')")
                    .IsFixedLength(true);

                entity.Property(e => e.CivilitePersonne)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                //entity.Property(e => e.DateNaissanceStagiaire).HasColumnType("date");

                //entity.Property(e => e.MatriculeCollaborateurAfpa)
                //    .HasMaxLength(8)
                //    .IsUnicode(false)
                //    .IsFixedLength(true);

                //entity.Property(e => e.MatriculeStagiaire)
                //    .HasMaxLength(8)
                //    .IsUnicode(false)
                //    .IsFixedLength(true);

                entity.Property(e => e.NomPersonne)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrenomPersonne)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasDiscriminator<string>("CatPersonne")
                .HasValue<Tiers>("P")
                .HasValue<CollaborateurAfpa>("F")
                .HasValue<Stagiaire>("S");

            });

            modelBuilder.Entity<Tiers>();

            modelBuilder.Entity<CollaborateurAfpa>(entity =>
            {
                entity.Property(e => e.MatriculeCollaborateurAfpa)
                .HasMaxLength(8)
                .IsRequired()
                .IsUnicode(false)
                .IsFixedLength();

            });

            modelBuilder.Entity<Stagiaire>(entity =>
            {
                entity.Property(e => e.MatriculeStagiaire)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength();

                entity.Property(e => e.DateNaissanceStagiaire)
                .HasColumnType("date");
            });

            modelBuilder.Entity<ProduitDeFormation>(entity =>
            {
                entity.HasKey(e => e.IdProduitFormation);

                entity.ToTable("ProduitDeFormation");

                entity.Property(e => e.IdProduitFormation)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DesignationProduitFormation)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StagiaireOffreFormation>(entity =>
            {
                entity.HasKey(e => new { e.IdPersonne, e.IdOffreFormation, e.IdEtablissement });

                entity.ToTable("Stagiaire_OffreFormation");

                entity.Property(e => e.IdEtablissement)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateEntreeStagiaire).HasColumnType("date");

                entity.Property(e => e.DateSortieStagiaire).HasColumnType("date");

                //entity.HasOne(d => d.IdPersonneNavigation)
                //    .WithMany(p => p.StagiaireOffreFormations)
                //    .HasForeignKey(d => d.IdPersonne)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Stagiaire_OffreFormation_Personne");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.StagiaireOffreFormations)
                    .HasForeignKey(d => new { d.IdOffreFormation, d.IdEtablissement })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stagiaire_OffreFormation_OffreFormation");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
