using PathCreation;
using UnityEngine;


namespace PathCreation.Examples
{
    [ExecuteInEditMode]
    public class Prefab_Manager : PathSceneTool
    {

        public GameObject holder;
        public float spacing = 20;
        public int PrefabCount = 7;
        const float minSpacing = .1f;
        public Prefab[] prefs;

        int tmp1 = 0, tmp2 = 1; // arka arkaya tekrarlanma kontrol ve engelleme


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
                float dst = 2;

                for (int i = 0; i < PrefabCount; i++)
                {
                    var rndprf = Random.Range(0, prefs.Length);
                    if (rndprf > 4 && tmp1 > 4)
                    {
                        tmp2 = rndprf;
                    }
                    if (rndprf > 4)
                    {
                        tmp1 = rndprf;
                    }

                    if (tmp1 == tmp2)
                    {
                        rndprf = Random.Range(0, prefs.Length - 2);
                        tmp1 = 1;
                        tmp2 = 0;
                    }

                    Vector3 point = path.GetPointAtDistance(dst);
                    Quaternion rot = path.GetRotationAtDistance(dst);
                    if (dst > 3 && dst < path.length - 5)
                    {
                        Instantiate(prefs[rndprf].prefab, point, rot, holder.transform);
                    }

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