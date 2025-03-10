namespace Generics
{
    #region stack
    class @Stack<T>
    {
        private T[] _items;
        private int _size;
        public @Stack(int h)
        {
            _items = new T[h];
        }

        #region Push_stack
        public void Push(T item)
        {
            if (_size == _items.Length)
            {
                T[] larger = new T[_size * 2];
                Array.Copy(_items, larger, _size);
                _items = larger;
            }
            _items[_size++] = item;
        }
        #endregion

        #region Pop_stack
        public T Pop()
        {
            if (_size == 0)
                throw new InvalidOperationException();

            T item = _items[--_size];
            _items[_size] = default(T);
            return item;
        }
        #endregion
    }
    #endregion

    #region Queue
    class @Queue<T>
    {
        private T[] _items;
        private int _size;
        private int _head;
        private int _tail;
        public @Queue(int h)
        {
            _items = new T[h];
        }
        public void Enqueue(T item)
        {
            if (_size == _items.Length)
            {
                T[] larger = new T[_size * 2];
                Array.Copy(_items, 0, larger, 0, _size);
                _items = larger;
            }
            _items[_tail] = item;
            _tail = (_tail + 1) % _items.Length;
            _size++;
        }
        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException();
            }
            T item = _items[_head];
            _items[_head] = default(T);
            _head = (_head + 1) % _items.Length;
            _size--;
            return item;
        }
    }
    #endregion

    #region Operations
    class Operations<T>
    {
        public T Add(T a, T b)
        {
            return (dynamic)a + (dynamic)b;
        }
        public T Sub(T a, T b)
        {
            return (dynamic)a - (dynamic)b;
        }
        public T Mul(T a, T b)
        {
            return (dynamic)a * (dynamic)b;
        }
        public T Div(T a, T b)
        {
            return (dynamic)a / (dynamic)b;
        }

    }
    #endregion

    #region Swap_in_out_ref
    class Swap<T>
    {
        public void SwapValues(ref T a, ref T b)
        {
            //ref changes the value of the variable passed to the method
            T temp = a;
            a = b;
            b = temp;
        }
        public void SwapValues(T a, T b, ref T c)
        {
            // ref is used to return more than one value and must not be assigned in the method
            T temp = a;
            a = b;
            b = c;
            c = temp;
        }
        public void SwapValues(T a, T b, T c, out T d)
        {
            // out is used to return more than one value and must be assigned in the method
            //out changes the value of the variable passed to the method
            T temp = a;
            a = b;
            b = c;
            d = temp;
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Generics_Stack_Queue
            int h;
            if (int.TryParse(Console.ReadLine(), out h))
            {
                Console.WriteLine(" enter nummber : " + h);

                #region stack
                //-- "Stack"
                @Stack<string> stack = new @Stack<string>(h);
                stack.Push("Ali");
                stack.Push("Fathi");
                stack.Push("Qayed");
                stack.Push("Rammdan");
                stack.Push("Mohamed");
                stack.Push("Ahmed");
                Console.WriteLine($" Stask = {stack.Pop()}");
                #endregion

                #region Queue
                // -- "Queue"
                @Queue<string> Queue = new @Queue<string>(h);
                Queue.Enqueue("Ali");
                Queue.Enqueue("Fathi");
                Queue.Enqueue("Qayed");
                Queue.Enqueue("Rammdan");
                Queue.Enqueue("Mohamed");
                Queue.Enqueue("Ahmed");
                Console.WriteLine($" Stask = {Queue.Dequeue()}");
                #endregion
            }
            else
            {
                Console.WriteLine("Error");
            }
            #endregion

            #region Generics_Operations
            Operations<int> operations = new Operations<int>();
            Console.WriteLine($"Add = {operations.Add(5, 5)}");
            Console.WriteLine($"Sub = {operations.Sub(5, 5)}");
            Console.WriteLine($"Mul = {operations.Mul(5, 5)}");
            Console.WriteLine($"Div = {operations.Div(5, 5)}");
            Console.WriteLine("---------------\n");
            Operations<float> ope = new Operations<float>();
            Console.WriteLine($"Add = {ope.Add(5.5f, 5.5f)}");
            Console.WriteLine($"Sub = {ope.Sub(5.5f, 5.5f)}");
            Console.WriteLine($"Mul = {ope.Mul(5.5f, 5.5f)}");
            Console.WriteLine($"Div = {ope.Div(5.5f, 5.5f)}");
            #endregion

            #region Swap_in_out_ref
            Swap<int> swap = new Swap<int>();
            int a = 5;
            int b = 10;
            Console.WriteLine($"Before Swap a = {a} , b = {b}");
            swap.SwapValues(ref a, ref b);
            Console.WriteLine($"After Swap a = {a} , b = {b}");
            Console.WriteLine("---------------\n");
            int c = 15;
            Console.WriteLine($"Before Swap a = {a} , b = {b} , c = {c}");
            swap.SwapValues(a, b, ref c);
            Console.WriteLine($"After Swap a = {a} , b = {b} , c = {c}");
            Console.WriteLine("---------------\n");
            int d = 20;
            Console.WriteLine($"Before Swap a = {a} , b = {b} , c = {c} , d = {d}");
            swap.SwapValues(a, b, c, out d);
            Console.WriteLine($"After Swap a = {a} , b = {b} , c = {c} , d = {d}");
            #endregion
        }
    }
}
