using UnityEngine;

public class Gesture{
    public float Duration;
}

public class PositionGesture : Gesture{
    public Vector3[] Positions;
}

// time needs to be fixed
/*
gesture = 3s

250 frames


3 - 250
0.34 - X

50fps

17/50 = 0.34s*/

/*
210 frames at 60fps = 3.5s

210 values

-------

300 frames at 50fps = 6s

300 values

*/

/*
20 fps
0.5 1 1.5 2 2.5 3 3.5 4 4.5 5 5.5 6 6.5 7 7.5 8 8.5 9 9.5 10

10 fps
1 2 3 4 5 6 7 8 9 10

5 fps
1 2.5 5 7.5 10


0.75s

20 * 3/4 = 15 => 7.5

10 * 3/4 = 7.5 => 7.5

5 * 3/4 = 3.75 = > 6.875
*/