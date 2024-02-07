using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class ProyectoDeMensajeriaAlexisAguileraMejiaContext : DbContext
{
    public ProyectoDeMensajeriaAlexisAguileraMejiaContext()
    {
    }

    public ProyectoDeMensajeriaAlexisAguileraMejiaContext(DbContextOptions<ProyectoDeMensajeriaAlexisAguileraMejiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Mensaje> Mensajes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-CHR9HTDV; Database=ProyectoDeMensajeriaAlexisAguileraMejia; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.ChatsId).HasName("PK__Chats__947411723EFF3373");

            entity.Property(e => e.ChatsId).HasColumnName("ChatsID");

            entity.HasOne(d => d.Usuario1Navigation).WithMany(p => p.ChatUsuario1Navigations)
                .HasForeignKey(d => d.Usuario1)
                .HasConstraintName("FK__Chats__Usuario1__1273C1CD");

            entity.HasOne(d => d.Usuario2Navigation).WithMany(p => p.ChatUsuario2Navigations)
                .HasForeignKey(d => d.Usuario2)
                .HasConstraintName("FK__Chats__Usuario2__1367E606");
        });

        modelBuilder.Entity<Mensaje>(entity =>
        {
            entity.HasKey(e => e.MensajesId).HasName("PK__Mensajes__02473F7BC8A5EDDA");

            entity.Property(e => e.MensajesId).HasColumnName("MensajesID");
            entity.Property(e => e.ChatsId).HasColumnName("ChatsID");
            entity.Property(e => e.FechaHoraMensaje).HasColumnType("date");
            entity.Property(e => e.Texto).HasColumnType("text");
            entity.Property(e => e.UsuariosId).HasColumnName("UsuariosID");

            entity.HasOne(d => d.Chats).WithMany(p => p.Mensajes)
                .HasForeignKey(d => d.ChatsId)
                .HasConstraintName("FK__Mensajes__ChatsI__173876EA");

            entity.HasOne(d => d.Usuarios).WithMany(p => p.Mensajes)
                .HasForeignKey(d => d.UsuariosId)
                .HasConstraintName("FK__Mensajes__Usuari__164452B1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuariosId).HasName("PK__Usuarios__48BE79E947F71401");

            entity.Property(e => e.UsuariosId).HasColumnName("UsuariosID");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Imagen).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
