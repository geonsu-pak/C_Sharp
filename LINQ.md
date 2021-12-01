List<int> A = new List<int>() { 1, 2, 3, 4 };
  
## Array(or List) 모든 값에 1 더하기
<pre>
var m = A.Select(i => i + 1).ToList();
</pre>
## Array(or List)에서 인덱스 전후 차분을 얻기
<pre>
var m = Enumerable.Range(1, A.Count - 1).Select(i => A[i] + A[i - 1]).ToList();
</pre>
<pre>
var m = A.Skip(1).Zip(A, (curr, prev) => curr + prev).ToList();
</pre>
<pre>        
var m = A.Skip(1).Select((x, index) => x + A[index]).ToList();
</pre>
