using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cloth;

namespace Cloth
{
    public class ClothChanger : MonoBehaviour
    {
        public List<SkinnedMeshRenderer> meshes;

        public Texture2D texture;
        public string shaderIdName = "_EmissionMap";

        private List<Texture2D> _defaultTextures;

        private void Awake()
        {
            _defaultTextures = new List<Texture2D>();
            foreach (var mesh in meshes)
            {
                _defaultTextures.Add((Texture2D)mesh.materials[0].GetTexture(shaderIdName));
            }
        }

        [NaughtyAttributes.Button]
        private void ChangeTexture()
        {
            foreach (var mesh in meshes)
            {
                mesh.materials[0].SetTexture(shaderIdName, texture);
            }
        }

        public void ChangeTexture(ClothSetup setup)
        {
            foreach (var mesh in meshes)
            {
                mesh.materials[0].SetTexture(shaderIdName, setup.texture);
            }
        }

        public void ResetTexture()
        {
            for (int i = 0; i < meshes.Count; i++)
            {
                meshes[i].materials[0].SetTexture(shaderIdName, _defaultTextures[i]);
            }
        }
    }
}
