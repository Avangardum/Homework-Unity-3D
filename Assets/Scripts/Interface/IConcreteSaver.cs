using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConcreteSaver
{
    void Save(Object obj);
    Object Load();
}
