using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class ScorelabelController : MonoBehaviour
{
    Text _label;

    void Start()
    {
        _label = GetComponent<Text>();
        var pool = Pools.pool;
        pool.GetGroup(Matcher.Score).OnEntityAdded += (group, entity, index, component) => updateScore(entity.score.value);
    }

    private void updateScore(int score)
    {
        _label.text = "Score " + score;
    }
}

