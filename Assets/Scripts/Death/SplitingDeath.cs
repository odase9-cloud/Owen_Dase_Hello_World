
using UnityEngine;

public class SplittingDeath : Death
{
    [Header("Splitting Settings")]
    public GameObject childAsteroidPrefab;
    public int childrenToSpawn;
    public float childScaleMultiplier;
    public float splitForce;
    public float minimumSplitScale;
    public int maxSplitDepth;
    public float spawnGap;

    [Header("Scoring")]
    public int scoreToAdd;

    [HideInInspector]
    public int splitDepth = 0;

    private bool hasDied = false;

    public override void Die()
    {
        if (hasDied)
            return;

        hasDied = true;

        if (GameManager.instance != null)
        {
            GameManager.instance.AddToScore(scoreToAdd);
        }

        if (childAsteroidPrefab != null &&
            splitDepth < maxSplitDepth &&
            transform.localScale.x > minimumSplitScale)
        {
            SplitAsteroid();
        }

        Destroy(gameObject);
    }


    private void SplitAsteroid()
    {
        Collider2D parentCollider = GetComponent<Collider2D>();

        float parentRadius = parentCollider != null
            ? parentCollider.bounds.extents.magnitude
            : 0.5f;

        for (int i = 0; i < childrenToSpawn; i++)
        {
            float angle = (360f / childrenToSpawn) * i
                + Random.Range(-15f, 15f);

            Vector2 direction = new Vector2(
                Mathf.Cos(angle * Mathf.Deg2Rad),
                Mathf.Sin(angle * Mathf.Deg2Rad)
            ).normalized;
            float spawnDistance = parentRadius + spawnGap;

            Vector3 spawnPosition = transform.position
                + (Vector3)(direction * spawnDistance);

            GameObject child = Instantiate(
                childAsteroidPrefab,
                spawnPosition,
                Quaternion.identity
            );

            Canvas healthCanvas = child.GetComponentInChildren<Canvas>(true);

            Vector3 originalCanvasScale = Vector3.one;

            if (healthCanvas != null)
            {
                originalCanvasScale = healthCanvas.transform.lossyScale;
            }

            child.transform.localScale =
                transform.localScale * childScaleMultiplier;

            if (healthCanvas != null)
            {
                Vector3 parentScale = healthCanvas.transform.parent.lossyScale;

                healthCanvas.transform.localScale = new Vector3(
                    originalCanvasScale.x / parentScale.x,
                    originalCanvasScale.y / parentScale.y,
                    originalCanvasScale.z / parentScale.z
                );
            }

            Collider2D childCollider = child.GetComponent<Collider2D>();

            float childRadius = childCollider != null
                ? childCollider.bounds.extents.magnitude
                : parentRadius * childScaleMultiplier;

            if (healthCanvas != null)
            {
                float scale = Mathf.Max(
                    Mathf.Abs(child.transform.lossyScale.x),
                    0.001f
                );

                healthCanvas.transform.localScale = Vector3.one / scale;
            }

            child.transform.position = transform.position
                + (Vector3)(direction *
                    (parentRadius + childRadius + spawnGap));

            SplittingDeath childDeath =
                child.GetComponent<SplittingDeath>();

            if (childDeath != null)
            {
                childDeath.splitDepth = splitDepth + 1;
            }

            astriod childAsteroid = child.GetComponent<astriod>();

            if (childAsteroid != null &&
                GameManager.instance != null)
            {
                GameManager.instance.RegisterAsteroid(childAsteroid);
            }

            Rigidbody2D rb = child.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddForce(
                    direction * splitForce,
                    ForceMode2D.Impulse
                );
            }
        }
    }

}

