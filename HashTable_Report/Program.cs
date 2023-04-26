namespace HashTable_Report
{
    internal class Program
    {
        /****************************************************** 
         * 해시테이블 (HashTable) 
         * 어떠한 자료형, 문자열 등 다양한 키값과 데이터를 해시함수를 사용한 해싱을 통해
         * 해시값으로 변환한 뒤 index를 사용하여 key - value 형식으로 테이블에 저장하는 자료구조다
         * 해시 테이블은 순서와 상관없이 index로 저장되기 때문에 삽입, 삭제, 탐색에 효율이 높은 성능을 보인다
         * 그래서 시간복잡도에서는 O(1)의 효율성을 보여준다
         * 대신 해시 테이블은 성능면에서 우수하지만 성능의 효율을 내기위해 많은 저장공간을
         * 요구하기애 처음 해시테이블을 생성할때 큰 공간을 가저야 하고
         * 데이터가 어느정도 할당량을 차지하게 되는 70%~80%정도에서 성능저하가 나타난다
         * 해시테이블에 index값을 저장할때 키값의 자료형 마다 여러 저장방식을 갖게 되는데
         * int형 숫자연산식, 문자열의 유니,아스키코드의 자릿수 등 다양하게 존재하지만 이마저도
         * 키값 중복에 의한 데이터충돌은 일어날수 있기애 같은 index에 연결리스트의 노드를 사용한 체이닝 방식과
         * 해시 충돌시 충돌지점의 다음지점에 삽입하는 개방주소법이 있다
         * 체이닝 방식의 경우 한 해시에 여러 데이터를 노드로 담을 수 있지만 그만큼 추가적인 저장공간이 필요하고
         * 개방주소법의 경우 추가적인 저장공간이 필요없지만 데이터가 차면서 성능저하를 일을킬수있다
         * 이러한 방식들 이외에 c#은 GetHashCode함수를 사용한 최적화된 해싱기능을 지원해주면 
         * 대외적으로 사용빈도가 높은 SHA-1, SHA-2등이 있다
         ******************************************************/


        static void Dictionary()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            dictionary.Add("마늘빵", 3600);
            dictionary.Add("에그마요", 5300);
            dictionary.Add("데리야끼", 5500);

            dictionary.Remove("에그마요");
            Console.WriteLine("에그마요 삭제");

            if (dictionary.ContainsKey("마늘빵"))                
            {
                Console.WriteLine("마늘빵이 메뉴에있습니다");
            }

            foreach (string key in dictionary.Keys)
            {
                Console.WriteLine(key);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("==============메뉴==============");
            Dictionary();
        }
    }
}