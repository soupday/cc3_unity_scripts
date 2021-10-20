using UnityEditor;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class TwistRigCorrection
{
    public class WeightedBoneConf
    {
        public string boneName;
        public float weight;
    }

    public class TwistCorrectionConf
    {
        public string name;
        public string sourceName;
        public TwistCorrectionData.Axis axis;
        public WeightedBoneConf[] twistBones;
    }

    public const float TWIST2_STRONG = 0.75f;
    public const float TWIST2_WEAK = 0.25f;
    public const float TWIST1_MID = 0.5f;

    public static TwistCorrectionConf[] TWIST_RIG =
    {
        new TwistCorrectionConf { name = "L Thigh", sourceName = "CC_Base_L_Calf", axis = TwistCorrectionData.Axis.Y,
            twistBones = new WeightedBoneConf[] {
                new WeightedBoneConf { boneName = "CC_Base_L_ThighTwist02", weight = TWIST2_STRONG },
                new WeightedBoneConf { boneName = "CC_Base_L_ThighTwist01", weight = TWIST2_WEAK },
            }
        },

        new TwistCorrectionConf { name = "L Calf", sourceName = "CC_Base_L_Foot", axis = TwistCorrectionData.Axis.Y, 
            twistBones = new WeightedBoneConf[] { 
                new WeightedBoneConf { boneName = "CC_Base_L_CalfTwist02", weight = TWIST2_STRONG },
                new WeightedBoneConf { boneName = "CC_Base_L_CalfTwist01", weight = TWIST2_WEAK },
            } 
        },

        new TwistCorrectionConf { name = "R Thigh", sourceName = "CC_Base_R_Calf", axis = TwistCorrectionData.Axis.Y,
            twistBones = new WeightedBoneConf[] {
                new WeightedBoneConf { boneName = "CC_Base_R_ThighTwist02", weight = TWIST2_STRONG },
                new WeightedBoneConf { boneName = "CC_Base_R_ThighTwist01", weight = TWIST2_WEAK },
            }
        },

        new TwistCorrectionConf { name = "R Calf", sourceName = "CC_Base_R_Foot", axis = TwistCorrectionData.Axis.Y,
            twistBones = new WeightedBoneConf[] {
                new WeightedBoneConf { boneName = "CC_Base_R_CalfTwist02", weight = TWIST2_STRONG },
                new WeightedBoneConf { boneName = "CC_Base_R_CalfTwist01", weight = TWIST2_WEAK },
            }
        },                        

        new TwistCorrectionConf { name = "L Upper Arm", sourceName = "CC_Base_L_Forearm", axis = TwistCorrectionData.Axis.Y,
            twistBones = new WeightedBoneConf[] {
                new WeightedBoneConf { boneName = "CC_Base_L_UpperarmTwist02", weight = TWIST2_STRONG },
                new WeightedBoneConf { boneName = "CC_Base_L_UpperarmTwist01", weight = TWIST2_WEAK },
            }
        },

        new TwistCorrectionConf { name = "L Forearm", sourceName = "CC_Base_L_Hand", axis = TwistCorrectionData.Axis.Y,
            twistBones = new WeightedBoneConf[] {
                new WeightedBoneConf { boneName = "CC_Base_L_ForearmTwist02", weight = TWIST2_STRONG },
                new WeightedBoneConf { boneName = "CC_Base_L_ForearmTwist01", weight = TWIST2_WEAK },
            }
        },

        new TwistCorrectionConf { name = "R Upper Arm", sourceName = "CC_Base_R_Forearm", axis = TwistCorrectionData.Axis.Y,
            twistBones = new WeightedBoneConf[] {
                new WeightedBoneConf { boneName = "CC_Base_R_UpperarmTwist02", weight = TWIST2_STRONG },
                new WeightedBoneConf { boneName = "CC_Base_R_UpperarmTwist01", weight = TWIST2_WEAK },
            }
        },

        new TwistCorrectionConf { name = "R Forearm", sourceName = "CC_Base_R_Hand", axis = TwistCorrectionData.Axis.Y,
            twistBones = new WeightedBoneConf[] {
                new WeightedBoneConf { boneName = "CC_Base_R_ForearmTwist02", weight = TWIST2_STRONG },
                new WeightedBoneConf { boneName = "CC_Base_R_ForearmTwist01", weight = TWIST2_WEAK },
            }
        },


        new TwistCorrectionConf { name = "L Knee (X)", sourceName = "CC_Base_L_Calf", axis = TwistCorrectionData.Axis.X,
            twistBones = new WeightedBoneConf[] {
                new WeightedBoneConf { boneName = "CC_Base_L_KneeShareBone", weight = -TWIST1_MID },
            }
        },

        new TwistCorrectionConf { name = "R Knee (X)", sourceName = "CC_Base_R_Calf", axis = TwistCorrectionData.Axis.X,
            twistBones = new WeightedBoneConf[] {
                new WeightedBoneConf { boneName = "CC_Base_R_KneeShareBone", weight = -TWIST1_MID },
            }
        },
        

        new TwistCorrectionConf { name = "L Elbow (X)", sourceName = "CC_Base_L_Forearm", axis = TwistCorrectionData.Axis.X,
            twistBones = new WeightedBoneConf[] {
                new WeightedBoneConf { boneName = "CC_Base_L_ElbowShareBone", weight = -TWIST1_MID },                
            }
        },        

        new TwistCorrectionConf { name = "R Elbow (X)", sourceName = "CC_Base_R_Forearm", axis = TwistCorrectionData.Axis.X,
            twistBones = new WeightedBoneConf[] {
                new WeightedBoneConf { boneName = "CC_Base_R_ElbowShareBone", weight = -TWIST1_MID },
            }
        },        


        new TwistCorrectionConf { name = "Neck", sourceName = "CC_Base_Head", axis = TwistCorrectionData.Axis.Y,
            twistBones = new WeightedBoneConf[] {
                new WeightedBoneConf { boneName = "CC_Base_NeckTwist02", weight = TWIST1_MID },                
            }
        },
    };

    [MenuItem("CC3/Rigging/Remove Twist Rig", priority = 101)]
    public static void DoRemoveTwistRig()
    {
        GameObject root = PrefabUtility.GetOutermostPrefabInstanceRoot(Selection.activeObject);

        if (!root) return;

        RigBuilder rigBuilder = root.GetComponent<RigBuilder>();
        if (rigBuilder) GameObject.DestroyImmediate(rigBuilder);

        Rig rig = root.GetComponentInChildren<Rig>();
        if (rig && rig.gameObject.name.Equals("Twist Rig")) DestroyEditorChildObjects(rig.gameObject);        
    }

    [MenuItem("CC3/Rigging/Add Twist Rig", priority = 100)]
    public static void DoAddTwistRig()
    {
        GameObject root = PrefabUtility.GetOutermostPrefabInstanceRoot(Selection.activeObject);

        if (!root) return;

        DoRemoveTwistRig();

        // make the animation rig        
        GameObject rigObject = AddEmpty(root, "Twist Rig");
        RigBuilder rigBuilder = Undo.AddComponent<RigBuilder>(root);
        Rig rig = Undo.AddComponent<Rig>(rigObject);
        RigLayer rigLayer = new RigLayer(rig, true);
        rigBuilder.layers.Add(rigLayer);

        foreach (TwistCorrectionConf tcc in TWIST_RIG)
        {
            Transform sourceBoneTransform = FindCharacterBone(root, tcc.sourceName).transform;
            GameObject rigChild = AddEmpty(rigObject, tcc.name);
            TwistCorrection tc = Undo.AddComponent<TwistCorrection>(rigChild);
            tc.weight = 1f;
            tc.data.sourceObject = sourceBoneTransform;
            tc.data.twistAxis = tcc.axis;

            WeightedTransformArray wta = new WeightedTransformArray(tcc.twistBones.Length);            
            int i = 0;
            foreach (WeightedBoneConf wbc in tcc.twistBones)
            {
                Transform twistBoneTransform = FindCharacterBone(root, wbc.boneName).transform;
                wta.SetTransform(i, twistBoneTransform);
                wta.SetWeight(i, wbc.weight);
                i++;
            }
            tc.data.twistNodes = wta;
        }
    }

    public static GameObject AddEmpty(GameObject parent, string name)
    {
        GameObject child = new GameObject();
        child.name = name;
        child.transform.SetParent(parent.transform);
        child.transform.localPosition = Vector3.zero;
        child.transform.localRotation = Quaternion.identity;
        return child;
    }

    public static GameObject FindCharacterBone(GameObject gameObject, string name)
    {
        if (gameObject)
        {
            if (gameObject.name.EndsWith(name))
                return gameObject;

            int children = gameObject.transform.childCount;
            for (int i = 0; i < children; i++)
            {
                GameObject found = FindCharacterBone(gameObject.transform.GetChild(i).gameObject, name);
                if (found) return found;
            }
        }

        return null;
    }

    public static void DestroyEditorChildObjects(GameObject obj, bool includeParent = true)
    {
        GameObject[] children = new GameObject[obj.transform.childCount];

        for (int i = 0; i < obj.transform.childCount; i++)
        {
            children[i] = obj.transform.GetChild(i).gameObject;
        }

        foreach (GameObject child in children)
        {
            GameObject.DestroyImmediate(child);
        }

        if (includeParent) GameObject.DestroyImmediate(obj);
    }
}
