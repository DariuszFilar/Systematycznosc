using System.Linq;

namespace Systematycznosc.ViewModels
{
    public class UserProfileViewModelWrapper
    {
        public UserProfileViewModel UserProfileViewModel { get; set; }
        public CredoViewModel CredoViewModel { get; set; }
        public TodoViewModel TodoViewModel { get; set; }
        public FamilyBirthdayViewModel FamilyBirthdayViewModel { get; set; }
        public FriendsBirthdayViewModel FriendsBirthdayViewModel { get; set; }
        public OthersBirthdayViewModel OthersBirthdayViewModel { get; set; }
        public RelationshipViewModel RelationshipViewModel { get; set; }
        public GoalsViewModel GoalsViewModel { get; set; }

        public bool IsInitialized => CredoViewModel.Credos != null
            && CredoViewModel.Credos.Any()
            && FamilyBirthdayViewModel.FamilyBirthday1 == null
            && FriendsBirthdayViewModel.FriendsBirthday1 == null
            && OthersBirthdayViewModel.OthersBirthday1 == null
            && RelationshipViewModel.Relationships == null
            && TodoViewModel.Todo1 == null && GoalsViewModel.AGoalName == null
            && GoalsViewModel.BGoalName == null;
    }
}