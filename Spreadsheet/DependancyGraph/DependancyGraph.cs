///Taimur Iftikhar
/// CS 3500 PS2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpreadsheetUtilities
{

    /// <summary>
    /// (s1,t1) is an ordered pair of strings
    /// t1 depends on s1; s1 must be evaluated before t1
    /// 
    /// A DependencyGraph can be modeled as a set of ordered pairs of strings.  Two ordered pairs
    /// (s1,t1) and (s2,t2) are considered equal if and only if s1 equals s2 and t1 equals t2.
    /// Recall that sets never contain duplicates.  If an attempt is made to add an element to a 
    /// set, and the element is already in the set, the set remains unchanged.
    /// 
    /// Given a DependencyGraph DG:
    /// 
    ///    (1) If s is a string, the set of all strings t such that (s,t) is in DG is called dependents(s).
    ///        (The set of things that depend on s)    
    ///        
    ///    (2) If s is a string, the set of all strings t such that (t,s) is in DG is called dependees(s).
    ///        (The set of things that s depends on) 
    //
    // For example, suppose DG = {("a", "b"), ("a", "c"), ("b", "d"), ("d", "d")}
    //     dependents("a") = {"b", "c"}
    //     dependents("b") = {"d"}
    //     dependents("c") = {}
    //     dependents("d") = {"d"}
    //     dependees("a") = {}
    //     dependees("b") = {"a"}
    //     dependees("c") = {"a"}
    //     dependees("d") = {"b", "d"}
    /// </summary>
    public class DependencyGraph
    {
        /// <summary>
        /// Creates an empty DependencyGraph.
        /// </summary> 
        public Dictionary<string, HashSet<string>> dependents;
        public Dictionary<string, HashSet<string>> dependees;
        public DependencyGraph()
        {
            this.dependents = new Dictionary<string, HashSet<string>>();
            this.dependees = new Dictionary<string, HashSet<string>>();
        }

  
        /// <summary>
        /// The number of ordered pairs in the DependencyGraph..
        /// </summary>
       

        public int Size
        {
            
            get{
                int temp_size = 0;
                foreach(KeyValuePair<string, HashSet<string>> kvp in this.dependents)
                {
                    foreach (string i in kvp.Value)
                        temp_size++;
                    

                }
                return temp_size;
                
                }
           
            
        }


        /// <summary>
        /// The size of dependees(s).
        /// This property is an example of an indexer.  If dg is a DependencyGraph, you would
        /// invoke it like this:
        /// dg["a"]
        /// It should return the size of dependees("a")
        /// </summary>
      
        public int this[string s]
        {

            get
            {
               if(this.dependees.ContainsKey(s))
                {
                    int count = 0;
                    foreach (string  i in dependees[s])
                    {
                        count++;
                    }
                    return count;
                }
                else
                {
                    throw new ArgumentNullException("Node does not exist");
                }
               

            }
        }


        /// <summary>
        /// Reports whether dependents(s) is non-empty.
        /// </summary>
        public bool HasDependents(string s)
        {
            if (this.dependents.ContainsKey(s)){
                if (this.dependents[s].Count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentNullException("Node does not exist");
            }
        }


        /// <summary>
        /// Reports whether dependees(s) is non-empty.
        /// </summary>
        public bool HasDependees(string s)
        {
            if (this.dependees.ContainsKey(s))
            {
                if (this.dependees[s].Count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentNullException("Node does not exist");
            }
        }


        /// <summary>
        ///  Enumerates dependents(s).
        /// </summary>
        public IEnumerable<string> GetDependents(string s)
        {
            List<string> dependents_s = new List<string>();

         
            foreach (KeyValuePair<string, HashSet<string>> kvp in this.dependents)
            {
                
                if (kvp.Key == s)
                {
                    foreach (string i in kvp.Value)
                    
                        dependents_s.Add(i);
                    
                    
                }
           
                
                   
            }
           
            return dependents_s;

        }


        /// <summary>
        /// Enumerates dependees(s).
        /// </summary>
        public IEnumerable<string> GetDependees(string s)
        {
            List<string> dependees_s = new List<string>();

            /// array list linked list hashset
            foreach (KeyValuePair<string, HashSet<string>> kvp in this.dependees)
            {

                if (kvp.Key == s)
                {
                    foreach (string i in kvp.Value)

                        dependees_s.Add(i);
                }
       
            }
            return dependees_s;

        }
        /// <summary>
        /// <para>Adds the ordered pair (s,t), if it doesn't exist</para>
        /// 
        /// <para>This should be thought of as:</para>   
        /// 
        ///
        /// </summary>
        /// <param name="s"> s must be evaluated first. T depend s on S</param>
        /// <param name="t"> t cannot be evaluated until s is</param>        /// 
        //private DependencyGraph d_graph = new DependencyGraph();
        public void AddDependency(string s, string t)
        {
        

            if (!this.dependents.ContainsKey(s))
            {
                this.dependents.Add(s, new HashSet<string>());

            }
            this.dependents[s].Add(t);

            if (!this.dependees.ContainsKey(t))
            {
                this.dependees.Add(t, new HashSet<string>());

            }
            this.dependees[t].Add(s);
        }


        /// <summary>
        /// Removes the ordered pair (s,t), if it exists
        /// </summary>h
        /// <param name="s"></param>
        /// <param name="t"></param>
        public void RemoveDependency(string s, string t)
        {
            if (!this.dependents.ContainsKey(s) || !this.dependees.ContainsKey(t)){
                return;
            }

            
            if(!this.dependents[s].Contains(t) || !this.dependees[t].Contains(s)){
                return;
            }

            this.dependents[s].Remove(t);
            this.dependees[t].Remove(s);
            
        }


        /// <summary>
        /// Removes all existing ordered pairs of the form (s,r).  Then, for each
        /// t in newDependents, adds the ordered pair (s,t).
        /// </summary>
        public void ReplaceDependents(string s, IEnumerable<string> newDependents)
        {

            if (!this.dependents.ContainsKey(s))
            {
                this.dependents.Add(s, new HashSet<string>());
                //HashSet<string> newDependents_set = new HashSet<string>();
                //newDependents_set.UnionWith(newDependents);
                //this.dependents[s] = newDependents_set;
                
            }
            List<string> temp_dependees = this.dependents[s].ToList();
            foreach(string t in temp_dependees)
            {
                this.RemoveDependency(s, t);
            }
            foreach (string r in newDependents)
            {
                this.AddDependency(s, r);
            }

        }


        /// <summary>
        /// Removes all existing ordered pairs of the form (r,s).  Then, for each 
        /// t in newDependees, adds the ordered pair (t,s).
        /// </summary>
        public void ReplaceDependees(string s, IEnumerable<string> newDependees)
        {
            if (!this.dependees.ContainsKey(s))
            {
                this.dependees.Add(s, new HashSet<string>());
            }
            List<string> temp_dependents = this.dependees[s].ToList();
            foreach (string t in temp_dependents)
            {
                this.RemoveDependency(t, s);
            }
            foreach (string r in newDependees)
            {
                this.AddDependency(r, s);
            }

        }
        
    }

}