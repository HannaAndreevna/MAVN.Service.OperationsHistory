using System.Threading.Tasks;
using MAVN.Service.OperationsHistory.Domain.Models;

namespace MAVN.Service.OperationsHistory.Domain.Repositories
{
    public interface IReferralStakesRepository
    {
        Task AddReferralStakeAsync(ReferralStakeDto referralStake);

        Task AddReferralStakeReleasedAsync(ReferralStakeDto referralStake);
    }
}
