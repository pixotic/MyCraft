using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScreen : MonoBehaviour
{
    World world;
    Text text;

    float frameRate;
    float timer;

    int halfWorldSizeInVoxels;
    int halfWorldSizeInChunks;

    // Start is called before the first frame update
    void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();
        text = GetComponent<Text>();

        halfWorldSizeInChunks = VoxelData.WorldSizeInBlocks / 2;
        halfWorldSizeInVoxels = VoxelData.WorldSizeInBlocks / 2;
    }

    // Update is called once per frame
    void Update()
    {
        string debugText = "MyCraft Debug Info";
        debugText += "\n";
        debugText += "==================";
        debugText += "\n";
        debugText += "FPS: " + frameRate;
        debugText += "\n\n";
        debugText += "XYZ: " + (Mathf.FloorToInt(world.player.transform.position.x) - halfWorldSizeInVoxels) + ", " + Mathf.FloorToInt(world.player.transform.position.y) + ", " + (Mathf.FloorToInt(world.player.transform.position.z) - halfWorldSizeInVoxels);
        debugText += "\n";
        debugText += "Chunk: " + (world.playerChunkCoord.x - halfWorldSizeInVoxels) + ", " + (world.playerChunkCoord.z - halfWorldSizeInVoxels);

        text.text = debugText;
        if (timer > 1f)
        {
            frameRate = (int)(1f / Time.unscaledDeltaTime);
            timer = 0;
        }
        else
            timer += Time.deltaTime;
    }
}
