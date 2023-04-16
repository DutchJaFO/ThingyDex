using Microsoft.AspNetCore.Components.Forms;
using ThingyDexer.ViewModel.Cult;

namespace ThingyDexer.Test
{
    [TestClass]
    public class CultNameSettingsEditModelValidatorTest
    {

        [TestMethod]
        public void TestValidator() {
            CultNameSettingsEditModel data = new CultNameSettingsEditModel();
            data.CultnameInputType = null;
            EditContext editContext = new(data);

#pragma warning disable CS0618 // Type or member is obsolete
            editContext.EnableDataAnnotationsValidation();
#pragma warning restore CS0618 // Type or member is obsolete

            bool test =  editContext.Validate();
            
            Assert.IsFalse(test);

        }

        [TestMethod]
        public void TestValidator2()
        {
            CultNameSettingsEditModel data = new CultNameSettingsEditModel();
            data.CultnameInputType = Model.General.CultnameInputType.TemplateAdjective1Noun1;

            EditContext editContext = new(data);

#pragma warning disable CS0618 // Type or member is obsolete
            editContext.EnableDataAnnotationsValidation();
#pragma warning restore CS0618 // Type or member is obsolete

            bool test = editContext.Validate();

            Assert.IsTrue(test);

        }
    }
}
