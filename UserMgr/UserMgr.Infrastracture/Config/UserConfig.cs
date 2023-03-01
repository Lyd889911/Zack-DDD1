using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserMgr.Domain.Entities;

namespace UserMgr.Infrastracture.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.OwnsOne(x => x.Phone, nb =>
            {
                nb.Property(b => b.PhoneNumber).HasMaxLength(20).IsUnicode(false);
            });
            //builder.HasOne(b => b.UserAccessFail).WithOne(f => f.User);
                //.HasForeignKey<UserAccessFail>(f => f.UserId);
            builder.Property("passwordHash").HasMaxLength(100).IsUnicode(false);
        }
    }
}