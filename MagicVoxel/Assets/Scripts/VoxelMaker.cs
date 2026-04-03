using UnityEngine;
// 신형 입력 시스템 네임스페이스 추가
using UnityEngine.InputSystem;
// List 사용을 위해 필수
using System.Collections.Generic;



// 사용자가 마우스를 클릭한 지점에 복셀을 1개 만들고 싶다.
// 필요 속성: 복셀 공장
public class VoxelMaker : MonoBehaviour
{
    // 복셀공장
    public GameObject voxelFactory;

    // 오브젝트 풀의 크기
    public int voxelPoolSize = 20;
    // 오브젝트 풀
    public static List<GameObject> voxelPool = new List<GameObject>();

    void Start()
    {
        // 오브젝트 풀에 비활성화된 복셀을 담고 싶다.
        for (int i = 0; i< voxelPoolSize; i++)
        {
            // - 복셀 공장에서 복셀 생성하기
            GameObject voxel = Instantiate(voxelFactory);
            // - 복셀 비활성화하기
            voxel.SetActive(false);
            // - 복셀을 오브젝트 풀에 담고 싶다.
            voxelPool.Add(voxel);
        }   
    }

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
                /*
                // 복셀 낱개로 생성
                GameObject voxel = Instantiate(voxelFactory);
                voxel.transform.position = hitInfo.point;
                */
                
                // 복셀 오브젝트 풀 이용하기
                // - 만약 오브젝트 풀에 복셀이 있다면
                if (voxelPool.Count>0)
                {
                    // - 오브젝트 풀에서 복셀을 하나 가져온다.
                    GameObject voxel = voxelPool[0];
                    // - 복셀을 활성화한다.
                    voxel.SetActive(true);
                    // - 복셀을 배치하고 싶다.
                    voxel.transform.position = hitInfo.point;
                    // - 오브젝트 풀에서 복셀을 제거한다.
                    voxelPool.RemoveAt(0);
                }
            }
        }
    }
}
