using Microsoft.AspNetCore.Components.Forms;
using ThingyDexer.ViewModel.Cult;

namespace ThingyDexer.Test
{
    [TestClass]
    public class CultNameSettingsEditModelValidatorTest
    {

        [TestMethod]
        public void TestValidator() {
            var data = new CultNameSettingsEditModel();
            data.CultnameInputType = null;
            var editContext = new EditContext(data);
            editContext.EnableDataAnnotationsValidation();
            var test =  editContext.Validate();
            
            Assert.IsFalse(test);

        }

        [TestMethod]
        public void TestValidator2()
        {
            var data = new CultNameSettingsEditModel();
            data.CultnameInputType = Model.General.CultnameInputType.TemplateAdjective1Noun1;

            var editContext = new EditContext(data);
            editContext.EnableDataAnnotationsValidation();
            var test = editContext.Validate();

            Assert.IsTrue(test);

        }
    }
}
