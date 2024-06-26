using AI_BehaviorTree_AIGameUtility;
using System.Collections.Generic;
using UnityEngine;

namespace LibraryCommon
{
    public class Sequence : INoeud
    {
        public List<INoeud> noeuds = new List<INoeud>();
        EtatNoeud etat = EtatNoeud.NotExecuted;

        public Sequence()
        {
            noeuds = new List<INoeud>();
        }

        public void Add(INoeud noeud)
        {
            noeuds.Add(noeud);
        }

        public EtatNoeud Execute(ref BehaviourTree bTree)
        {
            foreach (var n in noeuds)
            {
                etat = n.Execute(ref bTree);
                if (etat == EtatNoeud.Fail)
                {
                    return etat;
                }
            }
            return etat;
        }
    }
}
