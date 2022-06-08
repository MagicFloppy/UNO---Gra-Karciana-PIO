using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Card : MonoBehaviour {

    /*
        10 - pominiecie osoby
        11 - odwrocenie kierunku
        12 - dobranie 2 kart
        13 - zmiana koloru
        14 - dobranie 4 kart
    */

    int number;
    string color;
    GameObject cardObj;  // Obiekt w Unity

    public Card (int number, string color, GameObject object) {
        number = number;
        this.color = color;
        cardObj = object;
    }

    public GameObject loadCard(int x, int y, Transform parent) {  // po uruchomieniu informuje, gdzie zaladowac karte na ekranie
        GameObject temp = loadCard(parent);
        temp.transform.localPosition = new Vector2 (x, y+540);
        return temp;
    }

    public GameObject loadCard(Transform parent) {  // wykonuje cala konfiguracje ladowania. Uzywane, jesli karta nie wymaga okreslonej pozycji
        GameObject temp = Instantiate (cardObj);
        temp.name = color + number;
        if(number<10) {
            foreach (Transform childs in temp.transform) {
                if(childs.name.Equals("Cover"))
                    break;
                childs.GetComponent<Text>().text = number.ToString();
            }
            temp.transform.GetChild(1).GetComponent<Text>().color = returnColor(color);
        }
        else if(number==10 || number==11 || number==12) {
            temp.transform.GetChild(1).GetComponent<RawImage>().color = returnColor(color);
        }
        else if(number==13) {
            temp.transform.GetChild(0).GetComponent<Text>().text = "";
            temp.transform.GetChild(2).GetComponent<Text>().text = "";
        }
        temp.GetComponent<RawImage>().texture = Resources.Load(color+"Card") as Texture2D;
        temp.transform.SetParent(parent);
        temp.transform.localScale = new Vector3(1, 1, 1);
        return temp;
    }

    Color returnColor(string color) {  // zwraca kolor
        switch(color) {
            case "Green":
                return new Color32(0x55, 0xaa, 0x55, 255);
            case "Blue":
                return new Color32(0x55, 0x55, 0xfd, 255);
            case "Red":
                return new Color32(0xff, 0x55, 0x55, 255);
            case "Yellow":
                return new Color32(0xff, 0xaa, 0x00, 255);
        }
        return new Color(0, 0, 0);
    }

    public int getNumber() {
        return number;
    }

    public string getColor() {
        return color;
    }

    public bool Equals(Card other) {  // nadpisuje metode Equals, tak ze kolor lub liczba musza byc rowne
        return other.getNumber() == number || other.getColor().Equals(color);
    }

    public void changeColor(string newColor) {  // zmienia kolor karty
        color = newColor;
    }
}