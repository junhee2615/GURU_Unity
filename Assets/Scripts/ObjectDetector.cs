using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDetector : MonoBehaviour
{
    public class RaycastEvent : UnityEvent<Transform> { }   // 이벤트 클래스 정의
                                                            // 등록되는 이벤트 메소드는 Transform 매개변수 1개를 가지는 메소드

    public RaycastEvent raycastEvent = new RaycastEvent();   // 이벤트 클래스 인스턴스 생성 및 메모리 할당

    private Camera mainCamara;   // 광선을 생성하기 위한 Camera
    private Ray ray;   // 생성된 광선 정보 저장을 위한 Ray
    private RaycastHit hit;   // 광선에 부딪힌 오브젝트 정보 저장을 위한 RaycastHit

    private void Awake()
    {
        // "MainCamera" 태그를 가지고 있는 오브젝트 탐색 후 Camera 컴포넌트 정보 전달
        // 2020.2 이전 : GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 와 동일
        // 2020.2 버전부터 별도의 Camera 리스트에 담아두기 때문에 좀 더 가벼워졌다.
        // 2020.2 버전까지는 캐싱하는 것이 필수였지만 2020.2부터는 선택사항 (캐싱 or Camera.main 그대로 사용)
        mainCamara = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 왼쪽 버튼을 눌렀을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 카메라 위치에서 화면의 마우스 위치를 관통하는 광선 생성
            // ray.origin : 광선의 시작위치(=카메라 위치)
            // ray.direction : 광선의 진행방향
            ray = mainCamara.ScreenPointToRay(Input.mousePosition);

            // 2D 모니터를 통해 3D 월드의 오브젝트를 마우스로 선택하는 방법
            // 광선에 부딪히는 오브젝트를 검출해서 hit에 저장
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // 부딪힌 오브젝트의 Transform 정보를 매개변수로 이벤트 호출
                raycastEvent.Invoke(hit.transform);
            }
        }
    }
}
