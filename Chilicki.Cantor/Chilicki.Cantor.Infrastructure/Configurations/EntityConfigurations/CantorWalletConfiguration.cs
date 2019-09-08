using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Configurations.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chilicki.Cantor.Infrastructure.Configurations.EntityConfigurations
{
    public class CantorWalletConfiguration : BaseEntityConfiguration<CantorWallet>
    {
        public override void ConfigureEntity(EntityTypeBuilder<CantorWallet> builder)
        {
            
        }
    }
}
