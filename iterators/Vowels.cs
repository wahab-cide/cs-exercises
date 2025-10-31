public class Vowels : AbstractEnumerable<char> {
    protected string s;
    public Vowels(string s) {
        this.s = s;
    }
    public override IEnumerator<char> GetEnumerator() {
        return new VowelEnumerator(s);
    }
    public class VowelEnumerator : AbstractEnumerator<char> {
        protected string word;
        protected int i;
        protected bool IsVowel(char c) {
            switch (Char.ToLower(c)) {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    return true;
                default:
                    return false;
            }
        }
        public VowelEnumerator(string s) {
            // gather vowels
            word = "";
            foreach (char c in s) {
                if (IsVowel(c)) {
                    word += c;
                }
            }
            Reset();
        }
        public override bool MoveNext() {
            i++;
            return i < word.Length;
        }
        public override void Reset() {
            i = -1;
        }
        public override char Current {
            get {
                return word[i];
            }
        }
    }
}
