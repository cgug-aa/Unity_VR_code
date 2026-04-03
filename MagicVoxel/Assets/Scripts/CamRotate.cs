using UnityEngine;
// 최신 입력 시스템 네임스페이스 추가
using UnityEngine.InputSystem;

//마우스 입력에 따라 카메라를 회전시키고 싶다.
//필요 속성: 현재 각도, 마우스 감도
public class CamRotate : MonoBehaviour
{
    // 현재 각도
    Vector3 angle;
    // 마우스 감도
    // public float sensitivity = 200;
    public float sensitivity = 0.5f; // 최신 방식


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 시작할 때 현재 카메라의 각도를 적용한다.
        angle = Camera.main.transform.eulerAngles;
        // angle.x *= -1;

        // eulerAngles는 0~360도로 들어오므로 90도 제한을 위해 보정
        if (angle.x > 180) angle.x -= 360;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // 1. 사용자의 마우스 입력을 얻어와야 한다.
        // 마우스 좌우 입력을 받는다.
        float x = Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");
        
        // 2. 방향이 필요하다.
        angle.x += x* sensitivity * Time.deltaTime;
        angle.y += y* sensitivity * Time.deltaTime;
        
        angle.x = Mathf.Clamp(angle.x, -90, 90); //방향에 대한 각도 고정시키기
        // 3. 회전시키고 싶다.
        // 카메라의 회전 값에 새로 만들어진 회전 값을 할당한다.
        transform.eulerAngles = new Vector3(-angle.x, angle.y, transform.eulerAngles.z);
        */

        // 최신 방식으로 마우스 입력 받기
        if (Mouse.current != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();

            float x = mouseDelta.y; // 마우스 위아래 이동 -> X축 회전
            float y = mouseDelta.x; // 마우스 좌우 이동 -> Y축 회전

            // 방향 계산
            angle.x -= x * sensitivity * Time.deltaTime; // 마우스 이동 방향에 맞게 -= 사용
            angle.y += y * sensitivity * Time.deltaTime;

            angle.x = Mathf.Clamp(angle.x, -90, 90);

            // 회전 적용
            transform.eulerAngles = new Vector3(angle.x, angle.y, 0);
        }
    }
}
