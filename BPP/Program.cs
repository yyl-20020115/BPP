//BPP algorithm to calculate the n'th digit of Pi in hex mode;

long q_pow(long a, long b, long mod)
{
    long res = 1;
    while (b!=0)
    {
        if (0!=(b & 1))
            res = res * a % mod;
        a = a * a % mod;
        b /= 2;
    }
    return res;
}
double bbp(int n, long k, long b)
{
    double res = 0;

    for (int i = 0; i <= n; i++)
        res += (q_pow(16, n - i, 8 * i + b) * 1.0 / (8 * i + b));

    for (int i = n + 1; i <= n + 1000 + 1; i++)
        res += Math.Pow(16, n - i) * 1.0 / (8 * i + b);

    return k * res;
}
int Main(string[] args)
{
    int Case = 1;
    var line = Console.ReadLine();
    int.TryParse(line, out var T);
    while (T-->=0)
    {
        double ans = 0;
        line = Console.ReadLine();
        int.TryParse(line, out var n);
        ans = bbp(n - 1, 4, 1) - bbp(n - 1, 2, 4) - bbp(n - 1, 1, 5) - bbp(n - 1, 1, 6);
        ans = ans - (int)ans;
        if (ans < 0)
            ans += 1.0;
        ans *= 16.0;
        int x = (int)ans;
        char c = x >= 0 && x <= 9 ? (char)(x + '0') : (char)(x - 10 + 'A');
        Console.WriteLine($"Case #{Case++}: {n} \'{c}\'", Case++, n, c);
    }
    return 0;
}
return Main(args);
