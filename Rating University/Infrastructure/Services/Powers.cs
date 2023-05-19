namespace Rating_University.Infrastructure.Services
{
    public class Powers
    {
        List<Powers> powers = null;

        private int RoleId { get; set; }
        private bool isAdd { get; set; }
        private bool isEdit { get; set; }
        private int WhoRoleId { get; set; }
        private bool isAddMine { get; set; }
        private bool isEditMine { get; set; }
        private bool isAdmin { get; set; }

        public Powers(int roleId,
            bool isAdd,
            bool isEdit,
            int whoRoleId,
            bool isAddMine,
            bool isEditMine,
            bool isAdmin)
        {
            RoleId = roleId;
            this.isAdd = isAdd;
            this.isEdit = isEdit;
            WhoRoleId = whoRoleId;
            this.isAddMine = isAddMine;
            this.isEditMine = isEditMine;
            this.isAdmin = isAdmin;
        }

        public void f()
        {
           
        }

    }
}
