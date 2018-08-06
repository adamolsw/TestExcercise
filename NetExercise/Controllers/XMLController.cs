using NetExercise.Models;
using NetExercise.Repository;
using System.Web.Http;
using Unity.Attributes;

namespace NetExercise.Controllers
{
    public class XMLController : ApiController
    {
        private readonly ISaveToFile _saveToFile = null;
        private readonly IGetModel _getModel = null;
        public XMLController([Dependency("XML")]ISaveToFile saveToFile, IGetModel textProcessor)
        {
            this._saveToFile = saveToFile;
            this._getModel = textProcessor;
        }
        // POST: api/XML
        public void Post([FromBody] ApiModel apiModel)
        {
            var textModel = _getModel.GetModel(apiModel.Sentences);
            _saveToFile.SaveFile(textModel, apiModel.dirPath);
        }
    }
}
