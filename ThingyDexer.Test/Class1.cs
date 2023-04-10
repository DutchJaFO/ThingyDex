using Microsoft.AspNetCore.Components.Forms;
using ThingyDexer.ViewModel.Cult;

namespace ThingyDexer.Test
{
    [TestClass]
    public class Class1
    {

        [TestMethod]
        public void TestValidator() {
            var data = new CultNameSettingsEditModel();
            data.CultnameInputType = null;
            data.Test = "123";
            var editContext = new EditContext(data);
            editContext.EnableDataAnnotationsValidation();
            var test =  editContext.Validate();
            
            Assert.IsTrue(false);

        }
    }
}
