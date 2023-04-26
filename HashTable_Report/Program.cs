﻿namespace HashTable_Report
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
         * 요구하기애 처음 해시테이블을 생성할때 큰 공간을 가저야 하고 데이터를 할당할때 겹침현상인 충돌과
         * 데이터가 어느정도 할당량을 차지하게 되는 70%~80%정도에서 성능저하가 나타난다
         * 이러한 문제점들을 해결하기 위해서 
         * 
         * // <충돌해결방안 - 체이닝>
        // 해시 충돌이 발생하면 연결리스트로 데이터들을 연결하는 방식
        // 장점 : 해시테이블에 자료가 많아지더라도 성능저하가 적음
        // 단점 : 해시테이블 외 추가적인 저장공간이 필요 (노드를 사용해서)
        // 충돌자리에 LinkedList로 여러데이터를 저장해둬서 해당 자리에서 데이터를 탐색하는 방법을 씀

        // <충돌해결방안 - 개방주소법>	=> c#에서 체이닝 말고 개방주소법을씀
        // 해시 충돌이 발생하면 다른 빈 공간에 데이터를 삽입하는 방식 
        // 해시 충돌시 선형탐색, 제곱탐색, 이중해시 등을 통해 다른 빈 공간을 선정 (선형탐색의 경우 데이터가 많이 할당되면 효율성이 O(N)에 가까워짐)
        // 장점 : 추가적인 저장공간이 필요하지 않음, 삽입삭제시 오버헤드가 적음
        // 단점 : 해시테이블에 자료가 많아질수록 성능저하가 많음 (빈공간을 찾는동안생김 대부분 70%~80%에 이르면 성능저하가 나타남)
        // 해시테이블의 공간 사용률이 높을 경우 성능저하가 발생하므로 재해싱 과정을 진행함
        // 재해싱 : 해시테이블의 크기를 늘리고 테이블 내의 모든 데이터를 다시 해싱 (메모리 70%~80% 정도 차면 진행됨)

        // 엑셀에 있는 값들을 Dictionary에 옮기는 작업은 csv reader를 사용하면 된다
        // 플라이웨이트 패턴(경량화 패턴) : 여러 값은 데이터를 같은 키값으로 공용해서 사용

        // 1. key를 index로 해싱  (나눗셈, 자릿수, 문자열 추출 등 다양한 방법으로 키값을 정할수있음)
        // c#에서는 기본적으로 GetHashCode(해싱기능)을 지원해줌
        // 만약 구현한다 하면 대표적인 방법으로 SHA-1, SHA-2 등 해싱방법이 있음
         * 
         * 
         * 
         * 
         * 
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