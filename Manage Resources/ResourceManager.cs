using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.PrivateImplementationDetails;

namespace game2
{
    class ResourceManager
    {
        static ResourceManager _resourceManager = null;
        Dictionary<string, Resource> loadedResources;
        
       ResourceManager()
        {
            loadedResources = new Dictionary<string, Resource>();
        }

        public static ResourceManager CreateResource()
        {
            if (_resourceManager == null)
                _resourceManager = new ResourceManager();
            return _resourceManager;
        }


        public async Task<Resource> GetResource(string resourcePath)
        {
            Resource resource=null;
            if (IsResourceAlreadyLoaded(resourcePath))
            {
              
                loadedResources.TryGetValue(resourcePath, out resource);
           

            }
            else
            {
                Task<Resource> loadTask = new Task<Resource>(() => LoadResource(resourcePath));
                loadTask.Start();
                resource = await (loadTask);
               
            }

            return resource;
        }
        public Resource LoadResource(string resourcePath)
        {
            Resource resource = null;
            if (IsTextureFile(resourcePath))
            {
                resource = new TextureResource();
                loadedResources.Add(resourcePath, resource);
                resource.LoadResource(resourcePath);
              
            }

            return resource;

        }

        private bool IsResourceAlreadyLoaded(string path)
        {
            return loadedResources.ContainsKey(path);
        }
        private bool IsTextureFile(string path)
        {
            string[] fileName = path.Split('.');
            return fileName[1].Equals("png") || fileName[1].Equals("jpg");
          
        }
        private bool IsAudioFile(string path)
        {
            string[] fileName = path.Split('.');
            return fileName[1].Equals("mp3") || fileName[1].Equals("wav");

        }

    }
}
