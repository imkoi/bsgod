using UnityEngine;

namespace BSGod.Data
{
    public class BsPlayer
    {
        public static float HeadDefaultSize;
        public static int CharacterLayer = LayerMask.NameToLayer("Character");

        public bool isMine;
        public string name;
        public Camera camera;
        public Transform headTransform;
        public SphereCollider headCollider;
        public CharacterController characterController;
        public int layerMask;
        public bool isInvinsible => source.IsInvincible();

        public Character source;

        private BsPlayer(Character character, Camera playerCamera, bool isMine)
        {
            source = character;

            this.isMine = isMine;
            name = character.name;
            camera = playerCamera;

            var layers = GetCharacterLayers(character);
            layerMask = 1 << layers[0] | 1 << CharacterLayer;

            headCollider = (SphereCollider)character.headCollider;
            
            HeadDefaultSize = headCollider.radius;
            headTransform = character.headCollider.transform;
            characterController = character.controller.controller;
        }

        public static BsPlayer TryGetPlayer(Character character)
        {
            if(character != null)
            {
                if (character.headCollider == null)
                {
                    Debug.Log("character.headCollider");
                }
                else if (character.controller == null)
                {
                    Debug.Log("character.controller == null");
                    return null;
                }
                else
                {
                    var isMine = character.IsUserControlled();
                    if (isMine)
                    {
                        var foundedCamera = Object.FindObjectOfType<CameraController>();
                        if (foundedCamera != null && foundedCamera.mainCamera != null)
                        {
                            return new BsPlayer(character, foundedCamera.mainCamera, isMine);
                        }
                    }
                    else
                    {
                        return new BsPlayer(character, null, isMine);
                    }
                }
            }

            return null;
        }

        private int[] GetCharacterLayers(Character character)
        {
            var wh = character.GetParts();
            var layers = new int[wh.Length];
            for (var i = 0; i < wh.Length; i++)
            {
                layers[i] = wh[i].gameObject.layer;
            }

            return layers;
        }
    }
}
