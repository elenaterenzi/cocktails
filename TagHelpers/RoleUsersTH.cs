
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
  
namespace cocktails.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "i-role")]  
    public class RoleUsersTH : TagHelper
    {
        private UserManager<IdentityUser> userManager;
        private RoleManager<IdentityRole> roleManager;
  
        public RoleUsersTH(UserManager<IdentityUser> usermgr, RoleManager<IdentityRole> rolemgr)
        {
            userManager = usermgr;
            roleManager = rolemgr;
        }
  
        [HtmlAttributeName("i-role")]
        public string roleId { get; set; }
  
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            List<string> names = new List<string>();
            IdentityRole role = await roleManager.FindByIdAsync(roleId);
            if (role != null)
            {
                var userList = await userManager.GetUsersInRoleAsync(role.Name);
                foreach (var user in userList)
                {
                    names.Add(user.UserName);
                }
            }
            output.Content.SetContent(names.Count == 0 ? "No Users" : string.Join(", ", names));
        }
    }
}