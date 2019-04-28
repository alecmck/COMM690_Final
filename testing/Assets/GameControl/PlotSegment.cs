using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Once your reach your plot segment, you know that the previous have completed successfully.
//In other words if you reach segment 2, it is guareented that everything in segment 1 has been completed. 
public interface PlotSegment
{
    void selectDarkPhone();
    void selectLightPhone();
}
