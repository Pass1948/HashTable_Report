using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Dictionary<Tkey, TValue> where Tkey : IEnumerable<Tkey>  // key값과 비교할수있는 요소들만 올수있게 제약조건을 걸음
    {
        private const int DefaultCapacity = 1000;                         // 실사용시 최적화를 비교해서 용량을 잡아주면 되지만 일단 큰용량을 확보해두는것이 이후 기능들사용에 도움이 된다(성능위주)

        private struct Entry                                              // 기본 구성
        {
            public enum State { None, Using, Delected }                   // 해싱된 위치에 값이 들어간 상태를 확인하기 위해 열겨형 사용

            public State state;
            public int hashCode;
            public Tkey Key;
            public TValue value;
        }

        private Entry[] table;

        public Dictionary()                                               // 생성된 테이블에 용량 초기화
        {
            table = new Entry[DefaultCapacity];
        }

        // 탐색
        public TValue this[Tkey key]                                      // 해당 데이터 찾기
        {
            get
            {
                int index = Math.Abs(key.GetHashCode() % table.Length);   // 찾는 데이터의 key값을 해싱하여 index를 만들어 준다 (Math.Abs는 절대값만 나타는 클래스함수로 음수를 방지하기 위함임)
                                                                          // 테이블에 저장된 데이터들은 해싱되어 index로 저장되어 있기애 찾는 데이터도 해싱작업을 거친다
                while (table[index].state == Entry.State.Using)           // 해당 index와 테이블에 들어있는 index가 일치할때 까지 반복
                {
                    if (key.Equals(table[index].Key))                     // 동일한 key값일 경우
                    {
                        return table[index].value;                        // 해당 값 반환
                    }
                    if (table[index].state != Entry.State.None)           // 동일한 키값을 못찾고 비어있는 공간을 만났을 경우
                    {
                        break;                                            // 반복멈춤
                    }
                    index = ++index % table.Length;                       // 다음 index로 이동 (테이블안에 들어있는 index만큼 이동을 진행함)
                }
                throw new KeyNotFoundException();                         // 못찾을 경우 예외처리함
            }
            set
            {
                int index = Math.Abs(key.GetHashCode() % table.Length);   // 쓰기에도 동일하게 해싱과정을 진행한다

                while (table[index].state == Entry.State.Using)           // 동일한 index가 나올때 까지 진행
                {
                    if (key.Equals(table[index].Key))                     // 동일한 key값을 찾았을 경우 
                    {
                        table[index].value = value;                       // 해당 값으로 덮어쓰기를 진행함, 이 경우 key값은 중복인데 데이터를 교체하는 과정이라 주의를 요함
                        return;
                    }
                    if (table[index].state != Entry.State.None)           // 동일한 키값을 못찾고 비어있는 공간을 만났을 경우
                    {
                        break;                                            // 반복멈춤
                    }
                    index = ++index % table.Length;                       // 다음 index로 이동 (테이블안에 들어있는 index만큼 이동을 진행함)
                }
                throw new KeyNotFoundException();                         // 못찾을 경우 예외처리함
            }
        }

        public bool Remove(Tkey key)                                      // 삭제의 경우 bool형으로 찾으면 true(삭제) 못찾으면 false로 결과가 나오도록 한다
        {
            int index = Math.Abs(key.GetHashCode() % table.Length);       // 탐색때 처럼 해당 데이터를 찾기위해 해싱과정을 진행한다
           
            while (true)                                                
            {  
                if (table[index].state == Entry.State.Using)              // index가 같을 경우 
                {
                    if (key.Equals(table[index].Key))                     // 동일한 key값을 찾을 경우로 이중으로 검사해준다
                    {
                        table[index].state = Entry.State.Delected;        // 해당 데이터전부 삭제 후 Delected로 상태 처리 해준다
                        return true;
                    }
                }
                if (table[index].state == Entry.State.None)               // None일 경우 
                {
                    break;                                                // 반복멈춤
                }
                index = ++index % table.Length;                           // 다음 index로 이동 (테이블안에 들어있는 index만큼 이동을 진행함)
            }
            return false;                                                 // 해당 데이터를 못찾은 경우로 false로 반환한다
        }

        public void Add(Tkey key, TValue value)                           // 추가는 키값+데이터가 같이 들어가므로 두개의 매개변수를 쓴다
        {
            
            int index = Math.Abs(key.GetHashCode() % table.Length);      // 넣을 데이터를 해싱처리 하여 index값을 만들어 준다

            while (table[index].state != Entry.State.Using)              // 찾기, 삭제와 다르게 추가는 None or Delected 자리가 있을때 까지 반복한다
            {
                if (key.Equals(table[index].Key))                        // 키값이 똑같은 데이터일 경우 중복추가가 된 경우로 예외처리를 한다
                {
                    throw new ArgumentException();                       // c#은 키값이 동일한 다른자료를 추가할 경우 오류로 처리함
                }
                index = ++index % table.Length;                          // 이동시킨다
            }
            table[index].Key = key;                                      // 키값을 넣어준다
            table[index].value = value;                                  // 데이터값을 넣어준다
            table[index].state = Entry.State.Using;                      // 해당 자리를 Using상태로 만들어 준다
        }

    }
}
