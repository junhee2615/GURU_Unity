using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public float maxY;   // ��ġ�� �ִ� y ��ġ
    public float minY;   // ��ġ�� �ּ� y ��ġ
    public GameObject moleHitEffectPrefab;   // �δ��� Ÿ�� ȿ�� ������
    public AudioClip[] audioClips;   // �δ����� Ÿ������ �� ����Ǵ� ����
    public MoleHitTextViewer[] moleHitTextViewer;   // Ÿ���� �δ��� ��ġ�� Ÿ�� ���� �ؽ�Ʈ ���
    public GameController gameController;   // ���� ������ ���� GameController
    public ObjectDetector objectDetector;   // ���콺 Ŭ������ ������Ʈ ������ ���� ObejctDetector
    public Movement3D movement3D;   // ��ġ ������Ʈ �̵��� ���� Movement
    public AudioSource audioSource;   // �δ����� Ÿ������ �� �Ҹ��� ����ϴ� AudioSource

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
        audioSource = GetComponent<AudioSource>();

        // OnHit �޼ҵ带 ObjectDetector Class�� raycastEvent�� �̺�Ʈ�� ���
        // ObjectDetector�� raycastEvent.Invoke(hit.transform); �޼ҵ尡
        // ȣ��� ������ OnHit(Transform target) �޼ҵ尡 ȣ��ȴ�
        objectDetector.raycastEvent.AddListener(OnHit);
    }

    private void OnHit(Transform target)
    {
        if (target.CompareTag("Mole"))
        {
            MoleFSM mole = target.GetComponent<MoleFSM>();

            // �δ����� Ȧ �ȿ� ���� ���� ���� �Ұ�
            if (mole.MoleState == MoleState.UnderGround) return;

            // ��ġ�� ��ġ ����
            transform.position = new Vector3(target.position.x, minY, target.position.z);

            // ��ġ�� �¾ұ� ������ �δ����� ���¸� �ٷ� "UnderGround"�� ����
            mole.ChangeState(MoleState.UnderGround);

            // ī�޶� ����
            ShakeCamera.Instance.OnShakeCamera(0.1f, 0.1f);

            // �δ��� Ÿ�� ȿ�� ���� (Particle�� ������ �δ��� ����� �����ϰ� ����)
            GameObject clone = Instantiate(moleHitEffectPrefab, transform.position, Quaternion.identity);
            ParticleSystem.MainModule main = clone.GetComponent<ParticleSystem>().main;
            main.startColor = mole.GetComponent<MeshRenderer>().material.color;

            // ���� ���� (+50)
            //gameController.Score += 50;
            // �δ��� ���� ���� ó�� (����, �ð�, ����, ���)
            MoleHitProcess(mole);

            // ��ġ�� ���� �̵���Ű�� �ڷ�ƾ ���
            StartCoroutine("MoveUp");
        }
    }

    private IEnumerator MoveUp()
    {
        // �̵����� (0, 1, 0) [��]
        movement3D.MoveTo(Vector3.up);

        while (true)
        {
            if (transform.position.y >= maxY)
            {
                movement3D.MoveTo(Vector3.zero);

                break;
            }

            yield return null;
        }
    }

    private void MoleHitProcess(MoleFSM mole)
    {
        if (mole.MoleType == MoleType.Normal)
        {
            gameController.NormalMoleHitCount++;   // �⺻ �δ��� Ÿ�� Ƚ���� 1����
            gameController.Combo++;
            //gameController.Score += 50;
            // �⺻ x1�� 10�޺��� 0.5�� ���Ѵ�
            float scoreMultiple = 1 + gameController.Combo / 10 * 0.5f;
            int getScore = (int)(scoreMultiple * 50);
            // ���� ���� getScore�� Score�� �����ش�.
            gameController.Score += getScore;
            // MoleIndex�� ������ ������ �ξ��� ������ ���� �ڸ��� �ִ� TextGetScore �ؽ�Ʈ ���
            // �Ͼ�� �ؽ�Ʈ�� ���� ���� ǥ��
            //moleHitTextViewer[mole.MoleIndex].OnHit("Score +50", Color.white);
            moleHitTextViewer[mole.MoleIndex].OnHit("Score +"+getScore, Color.white);
        }
        else if (mole.MoleType == MoleType.Red)
        {
            gameController.RedMoleHitCount++;   // ������ �δ��� Ÿ�� Ƚ���� 1����
            gameController.Combo = 0;   // ������ �δ����� ����ġ�� �޺� 0
            gameController.Score -= 300;
            // ������ �ؽ�Ʈ�� ���� ���� ǥ��
            moleHitTextViewer[mole.MoleIndex].OnHit("Score -300", Color.red);
        }
        else if (mole.MoleType == MoleType.Blue)
        {
            gameController.BlueMoleHitCount++;   // �Ķ��� �δ��� Ÿ�� Ƚ���� 1����
            gameController.Combo++;
            gameController.CurrentTime += 3;
            // �Ķ��� �ؽ�Ʈ�� ���� ���� ǥ��
            moleHitTextViewer[mole.MoleIndex].OnHit("Time +3", Color.blue);
        }

        // ���� ��� (Normal=0, Red=1, Blue=2)
        PlaySound((int)mole.MoleType);
    }

    private void PlaySound(int index)
    {
        audioSource.Stop();
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
