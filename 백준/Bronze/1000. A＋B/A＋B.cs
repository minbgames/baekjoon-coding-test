// 입력받기
string input = Console.ReadLine(); // 한 줄로 입력받기
string[] numbers = input.Split(' '); // 공백으로 분리

// A와 B 추출 및 정수 변환
int A = int.Parse(numbers[0]);
int B = int.Parse(numbers[1]);

// 합 계산 및 출력
Console.WriteLine(A + B);