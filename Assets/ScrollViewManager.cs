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
        private Text NameText;

        public Button ActionBtn;

        public Image SelectImg;

        public string Name { get; set; }

        public ContentData(GameObject prefab, GameObject parentObj)
        {
            var obj = Instantiate(prefab, parentObj.transform);

            NameText = obj.transform.Find("NameLabel").GetComponent<Text>();

            ActionBtn = obj.transform.GetComponent<Button>();

            SelectImg = obj.transform.Find("SelectImg").GetComponent<Image>();
        }

        public void SetData(string setName)
        {
            Name = setName;

            NameText.text = Name;
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

    public int SelectNo { get; set; }

    private void Start()
    {
        ContentList = new List<ContentData>();

        addBtn.onClick.AddListener(() =>
        {
            var content = new ContentData(contentPrefab, scrollContent);

            content.SetData($"私は:{ContentList.Count}");

            content.ActionBtn.onClick.AddListener(() =>
            {
                SelectNo = ContentList.Count - 1;
            });

            ContentList.Add(content);
        });

        editBtn.onClick.AddListener(() =>
        {

        });

        deleteBtn.onClick.AddListener(() =>
        {


            //指定番号を消去
            ContentList.RemoveAt(SelectNo);
        });
    }

}
