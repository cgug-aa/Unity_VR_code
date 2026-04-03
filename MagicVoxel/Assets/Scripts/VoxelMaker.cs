using UnityEngine;
// 신형 입력 시스템 네임스페이스 추가
using UnityEngine.InputSystem;

// 사용자가 마우스를 클릭한 지점에 복셀을 1개 만들고 싶다.
// 필요 속성: 복셀 공장


public class VoxelMaker : MonoBehaviour
{
    // 복셀공장
    public GameObject voxelFactory;

    // Update is called once per frame
    void Update()
    {
        /*
        //사용자가 마우스를 클릭한 지점에 복셀을 1개 만들고 싶다.
        // - 사용자가 마우스를 클릭했다면
        if (Input.GetButtonDown("Fire1"))
        {
            // - 마우스의 위치가 바닥 위에 위치해 있다면
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            if(Physics.Raycast(ray, out hitInfo))
            {
                // - 복셀 공장에서 복셀을 만들어야 한다.
                GameObject voxel = Instantiate(voxelFactory);
                // - 복셀을 배치하고 싶다.              
                voxel.transform.position = hitInfo.point;
            }
        }*/

        // - 사용자가 마우스를 클릭했다면
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // - 마우스의 위치가 바닥 위에 위치해 있다면
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                GameObject voxel = Instantiate(voxelFactory);
                voxel.transform.position = hitInfo.point;
            }
        }
    }
}
