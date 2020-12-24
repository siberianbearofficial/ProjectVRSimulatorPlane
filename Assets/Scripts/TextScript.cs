using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{

    public GameObject text;
    public TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textMesh = (TextMesh)text.transform.GetComponent(typeof(TextMesh));
        if (Input.GetKey("1"))
        {
            textMesh.text = "1. Перед полетом тща-\nтельно осмотрите кабину\n воздушного судна. Орга-\nны контроля самолетом\nдолжны двигаться бес-\nпрепятственно.\n";
        }
        if (Input.GetKey("2"))
        {
            textMesh.text = "2. После проверки орга-\nнов контроля и работы от-\nдельных механизмов пере-\nходите к началу полета,\nкоторое именуется взлет.\n";
        }
        if (Input.GetKey("3"))
        {
            textMesh.text = "3. Переходить к взлету\nможно только после\nполучения разрешения.\nВыровнять самолет на\nвзлетно-посадочной\nполосе (ВПП) и\nубедиться в том, что\nкурс соответствует курсу\nВПП\n";
        }
        if (Input.GetKey("4"))
        {
            textMesh.text = "4. Уберите рычаг руч-\nного тормоза и убе-\nдитесь, что соответст-\nвующий датчик погас\n";
        }
        if (Input.GetKey("5"))
        {
            textMesh.text = "5. Увеличьте обороты\nдвигателей до 40%.\nДайте стабилизироваться\nоборотам, чтобы избе-\nжать разворачивающего\nмомента при разбеге\n";
        }
        if (Input.GetKey("6"))
        {
            textMesh.text = "6. Дождитесть установ-\nки взлетного режима в\n60 узлов.\n";
        }
        if (Input.GetKey("7"))
        {
            textMesh.text = "7. При достижении ско-\nрости в 60 узлов слег-\nка придавливать РУД от\nсебя до достижения\n80 узлов\n";
        }
        if (Input.GetKey("8"))
        {
            textMesh.text = "8. При достижении 80\nузлов убрать руку\nс РУД. Начните тянуть\nштурвал на себя. Реко-\nмендуемый темп ускоре-\nния – 2-3 градуса в секун-\nду. Таким образом в тече-\n";
        }
        if (Input.GetKey("u"))
        {
            textMesh.text = "нии 3-4 секунд произой-\nдет отрыв самолета. Про-\nдолжайте тянуть штурвал\nна себя теми же тем-\nпами до достижения тан-\nгажа в 15 градусов\n";
        }
        if (Input.GetKey("9"))
        {
            textMesh.text = "9. После взлета ис-\nпользовать автого-\nризонт как основной\nисточник информации о\nположении самолета. Соз-\nдайте устойчивый набор\nвысоты.\n";
        }
        if (Input.GetKey("o"))
        {
            textMesh.text = "10. При достижении\nустойчивого набора шасси\nпереведите рычаг управ-\nления шасси в верх-\nнее положение\n";
        }
    }
}
