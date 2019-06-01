using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewManager : MonoBehaviour
{
    /// <summary>
    /// ScrollViewに追加するprefabのここに持たせる情報
    /// </summary>
    public class ContentData
    {
        private Transform objTransform;

        private Text NameText;

        public Button ActionBtn;

        public Image SelectImg;

        public string Name { get; set; }

        public ContentData(GameObject prefab, GameObject parentObj)
        {
            var obj = Instantiate(prefab, parentObj.transform);

            objTransform = obj.transform;

            NameText = obj.transform.Find("NameLabel").GetComponent<Text>();

            ActionBtn = obj.transform.GetComponent<Button>();

            SelectImg = obj.transform.Find("SelectImg").GetComponent<Image>();
            
        }

        public void SetData(string setName)
        {
            objTransform.gameObject.name = setName;

            Name = setName;

            NameText.text = Name;
        }

        public void SetSelect(bool flag)
        {
            SelectImg.enabled = flag;
        }

        public void Delete()
        {
            Destroy(this.objTransform.gameObject);
        }
    }


    [SerializeField]
    private GameObject scrollContent;

    [SerializeField]
    private Button addBtn;

    [SerializeField]
    private Button editBtn;

    [SerializeField]
    private Button deleteBtn;

    [SerializeField]
    private GameObject contentPrefab;

    public List<ContentData> ContentList { get; set; }

    public int SelectNo;

    private void Start()
    {
        ContentList = new List<ContentData>();

        addBtn.onClick.AddListener(() =>
        {
            var content = new ContentData(contentPrefab, scrollContent);

            var count = ContentList.Count;

            content.SetData($"私は:{count}");

            content.ActionBtn.onClick.AddListener(() =>
            {
                foreach(var listData in ContentList)
                {
                    listData.SetSelect(false);
                }
                
                SelectNo = count;
                content.SetSelect(true);
            });

            ContentList.Add(content);
        });

        editBtn.onClick.AddListener(() =>
        {

        });

        deleteBtn.onClick.AddListener(() =>
        {
            //Hierarchyのオブジェクトを消去
            ContentList[SelectNo].Delete();

            //指定番号を消去
            ContentList.RemoveAt(SelectNo);
        });
    }

}
