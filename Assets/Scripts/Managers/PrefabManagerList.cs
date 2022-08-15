using PathCreation;
using UnityEngine;


namespace PathCreation.Examples
{
    [ExecuteInEditMode]
    public class PrefabManagerList : PathSceneTool
    {

        public GameObject holder;
        public float spacing = 20;
        const float minSpacing = .1f;
        public Prefab[] prefs;

        [System.Serializable]
        public class Prefab
        {
            public GameObject prefab;

        }

        void Generate()
        {
            DestroyObjects();


            if (pathCreator != null && holder != null)
            {

                VertexPath path = pathCreator.path;

                spacing = Mathf.Max(minSpacing, spacing);
                float dst = 15;

                for (int i = 0; i < prefs.Length; i++)
                {
                    var rndprf = Random.Range(0, prefs.Length);
                  

                    Vector3 point = path.GetPointAtDistance(dst);
                    Quaternion rot = path.GetRotationAtDistance(dst);

                        Instantiate(prefs[i].prefab, point, rot, holder.transform);


                    dst += spacing;
                }


            }

        }



        void DestroyObjects()
        {
            int numChildren = holder.transform.childCount;
            for (int i = numChildren - 1; i >= 0; i--)
            {
                DestroyImmediate(holder.transform.GetChild(i).gameObject, false);
            }
        }

        protected override void PathUpdated()
        {
            if (pathCreator != null)
            {
                Generate();
            }
        }


    }

}