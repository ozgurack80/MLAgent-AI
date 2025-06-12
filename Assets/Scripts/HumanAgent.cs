using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class HumanAgent : Agent
{
    public Transform wolf; // Kurdu referans alıyoruz
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private float survivalTime = 0f;
    private float maxSurvivalTime = 60f;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void OnEpisodeBegin()
    {
        float minX = -2f; 
        float maxX = 7f;
        float minY = -4f;
        float maxY = 4f;

        transform.localPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        wolf.localPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);

        survivalTime = 0f;
    }


    public override void OnActionReceived(ActionBuffers actions)
    {
        float h = actions.ContinuousActions[0];
        float v = actions.ContinuousActions[1];

        Vector2 move = new Vector2(h, v);
        rb.linearVelocity = move * moveSpeed;

        // Yakalandı mı?
        float distanceToWolf = Vector2.Distance(transform.localPosition, wolf.localPosition);
        if (distanceToWolf < 1.0f)
        {
            SetReward(-1f); // Ceza
            EndEpisode();
        }

        // Hayatta kalma süresi artıyor
        survivalTime += Time.deltaTime;

        // 60 saniye boyunca kurt kaçırılırsa ödül ver
        if (survivalTime >= maxSurvivalTime)
        {
            SetReward(+1f); // Ödül
            EndEpisode();
        }
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition); // Kendi pozisyonu
        sensor.AddObservation(wolf.localPosition);      // Kurdun pozisyonu
        sensor.AddObservation(wolf.localPosition - transform.localPosition); // Aradaki fark
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var ca = actionsOut.ContinuousActions;
        ca[0] = Input.GetAxis("Horizontal");
        ca[1] = Input.GetAxis("Vertical");
    }
}
