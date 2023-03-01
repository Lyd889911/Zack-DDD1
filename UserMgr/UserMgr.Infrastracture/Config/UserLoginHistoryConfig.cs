using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain.Entities;

namespace UserMgr.Infrastracture.Config
{
    public class UserLoginHistoryConfig : IEntityTypeConfiguration<UserLoginHistory>
    {
        public void Configure(EntityTypeBuilder<UserLoginHistory> builder)
        {
            builder.ToTable("user_login_history");
            builder.OwnsOne(x => x.Phone, nb =>
            {
                nb.Property(b => b.PhoneNumber).HasMaxLength(20).IsUnicode(false);
            });
        }
    }
}
