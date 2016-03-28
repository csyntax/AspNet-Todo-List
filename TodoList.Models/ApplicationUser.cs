using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<TodoItem> todoItems;

        public ApplicationUser()
        {
            this.todoItems = new HashSet<TodoItem>();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }

        public virtual ICollection<TodoItem> TodoItems
        {
            get
            {
                return this.todoItems;
            }

            set
            {
                this.todoItems = value;
            }
        }
    }
}
