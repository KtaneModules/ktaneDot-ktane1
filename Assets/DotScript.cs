using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class DotScript : MonoBehaviour
{
    public KMAudio audio;
    public KMAudio.KMAudioRef audioRef;
    public KMBombInfo bomb;
	public KMBombModule module;
    public KMSelectable submit;
    public KMSelectable upScroll;
    public TextMesh topText, bottomText;
    public Transform topTextMovement, bottomTextMovement;

    private string[][] songLyrics = new string[][] {
        new string[] { "大変申し訳ありませんが、", "この動画はアップロード者が削除した為、", "ご覧になることができません。", "またの御アクセスをお待ちしております。", "携帯ゲームの裏、", "フタを開けてみて、", "空っぽだったはずなのに、", "淡い光が漏れていたので、", "いたずらに覗いたら、", "デンチが腐っていた。", "掌から滑り落ち、", "叩きつけられて、", "やむ終えず覗いたら、", "画面が割れていました。", "たわむれに書いた傘の中、", "ひとりでに骨が折れ、", "心地よい音　頭蓋の中、", "湿って砕けました。", "湧き出た光る水を、", "飲んでみたくなり、", "空っぽだったはずなのに、", "器から溢れてしまいそうで、", "ひとくち含んでみたら、", "甘すぎて吐き出したよ。", "漏れ出た黒い液が、", "怖くてたまらないのに", "指先が触れてしまい、", "血液と混ざりました。", "心地よい音　頭蓋の中、", "ひとりでに骨が折れ、", "たわむれに書いた傘の中、", "全てあなたの所為です。", "心地よい音　頭蓋の中、", "ひとりでに骨が折れ、", "たわむれに書いた傘の中、", "全て██の所為です。", "沢山の目が光り、", "見つめていたのか。", "またの御アクセスをお待ちしております。" }, 
        new string[] { "大変申し訳ありませんが、", "この動画はアップロード者が削除した為、", "ご覧になることができません。", "またの御アクセスをお待ちしております。", "蛍光灯の明かりの下、", "艷やかな足跡がある、", "シアン化物の甘い匂いで、", "手足が痺れはじめ。", "からだ中に差し込まれてく、", "いかにもな理由を添えて", "どうして針はこちらを向いて、", "繰り言を吐くの？", "砂を噛み、", "鏤骨を齧り、", "ナメクジが死んでました。", "それは万有引力の、", "様なモノであり、", "抗えば抗う程、", "青く燃え上がるのです。", "それはテレメトリ信号が、", "指し示す通り、", "もがく腕や足はもう、", "意味をなさないのです。", "後は野となれ山となれと、", "何も成し遂げられず居る、", "偶像崇拝妄信者が、", "溜飲を下げる。", "四辺形に収容された、", "路傍の人の慰みが、", "植え付ける様にこちらを向いて、", "咎めるのでしょう。", "砂を噛み、", "鏤骨を齧り、", "ナメクジが溶けていました。", "それは万有引力の、", "様なモノであり、", "抗えば抗う程、", "青く燃え上がるのです。", "それはテレメトリ信号が、", "指し示す通り、", "もがく腕や足はもう、", "意味をなさないのです。", "這いずり方が、", "思い出せなくなりました、", "全てあなたの所為です。", "それは万有引力の、", "様なモノであり、", "抗えば抗う程、", "青く燃え上がるのです。", "それはテレメトリ信号が、", "指し示す通り、", "もがく腕や足はもう、", "意味をなさないのです。", "柔らかい場所を、", "沢山の指先で、", "触れようとしていたのか。", "またの御アクセスをお待ちしております。" },
        new string[] { "本日は＊＊＊に", "御アクセス頂き、", "ありがとうございます", "大変申し訳ありませんが、", "この動画はアップロード者が＊＊＊した為、", "ご覧になることができません。", "またの御アクセスをお待ちしております。", "穴の空いた両の手で、", "喉の渇きは潤せず、", "甘いはずの水は、", "掬っても零れてゆく。", "穴の空いた両の手で、", "目を遮ることは出来ず、", "柔らかな熱源が、", "視神経を焼き切りました。", "腕の無い三重の", "振り子が描き出す背骨を、", "短慮な烏が", "啄むのでした。", "不快な音を鳴らして、", "無い爪を立てる、", "形骸化した心地よさには、", "遅効性の毒があるのです。", "見たいモノだけを見て、", "目が覚めた時はすでに遅し、", "死に至るでしょう。", "全てあなたの所為です。", "穴の空いた両の手で、", "逃げ水を追いかけて行く、", "気が付けば遠くまで、", "歩いてしまいました。", "穴の空いた両の手で、", "硝子の向こうをそっと見る、", "意味のない言葉は、", "此の世に存在しないのです。", "陰になり日向になり、", "顰蹙の密売商人が、", "土足で踏み込んで", "来るのでした。", "ただ緩やかに黄昏れて行く、", "誰も止め方がわからずに、", "心臓の位置を避けるようにと", "横から杭が打ち込まれました。", "不快な音を鳴らして、無い爪を立てる、", "形骸化した心地よさには、", "遅効性の毒があるのです。", "見たいモノだけを見て、", "信じたいモノを信じ、", "沢山の足の音が、", "近づいていたのか。", "またの御アクセスをお待ちしております。" },
    };
    private string[] chosenLyrics = new string[5];
    private int chosenSong;
    private static Vector3 bottomPos = new Vector3(0f, 0.016f, -0.09f);
    private string[] shuffledLyrics = new string[5];
    private int lyricIndex = 0, lyricsSubmitted = 0;
    private string selectedLyric;
    private float upScrollSpeed = 1f;
    private bool[] submittedText = new bool[5];

    private static int moduleIdCounter = 1;
    private int moduleId;
    private bool scrollable, scrolling, submittable = true, moduleSolved; 

    void Awake()
    {
    	moduleId = moduleIdCounter++;
        upScroll.OnInteract += delegate { upScrollHandler(); return false; };
        upScroll.OnInteractEnded += release;
        submit.OnInteract += delegate { submitHandler(); return false; };
        module.OnActivate += Activate;
        bomb.OnBombExploded += delegate
        {
            if (scrolling) { release(); }
        };
    }

    void Activate()
    {
        chosenSong = UnityEngine.Random.Range(0, 3);
        int lyric = UnityEngine.Random.Range(0, songLyrics[chosenSong].Length - 4);
        string fullLyrics = "";
        for (int i = 0; i < 5; i++) 
        { 
            chosenLyrics[i] = songLyrics[chosenSong][lyric + i]; 
            if (i != 4)
            {
                fullLyrics = fullLyrics + songLyrics[chosenSong][lyric + i] + " / ";
            }
            else
            {
                fullLyrics = fullLyrics + songLyrics[chosenSong][lyric + i];
            }
        }
        Debug.LogFormat("[Dot #{0}] The chosen lyrics are {1} taken from Song {2} in the manual.", moduleId, fullLyrics, chosenSong+1);
        shuffledLyrics = chosenLyrics.ToArray();
        shuffledLyrics.Shuffle();
        topTextMovement.localPosition = bottomPos;
        bottomTextMovement.localPosition = bottomPos;
        StartCoroutine("topCycleHandler");
        StartCoroutine("bottomCycleHandler");
    }

    IEnumerator topCycleHandler()
    {
        while (!moduleSolved)
        {
            topText.text = shuffledLyrics[lyricIndex];
            if (submittedText[lyricIndex + 1 > 4 ? 0 : lyricIndex + 1])
            {
                topText.color = new Color(0f, 1f, 0f, 1f);
            }
            else
            {
                topText.color = new Color(1f, 1f, 1f, 1f);
            }
            lyricIndex++;
            lyricIndex %= 5;
            topTextMovement.localPosition = bottomPos;
            float posZ = topTextMovement.localPosition.z;
            float posY = topTextMovement.localPosition.y;
            while (posZ <= 0.09f)
            {
                posZ += 0.001f;
                topTextMovement.localPosition = new Vector3(0f, posY, posZ);
                float speed = 0.02f * upScrollSpeed;
                yield return new WaitForSecondsRealtime(speed);
            }
        }
    }

    IEnumerator bottomCycleHandler()
    {
        bottomTextMovement.localPosition = new Vector3(0f, 0.0152f, 0.1f);
        while (topTextMovement.localPosition.z < 0) { yield return null; }
        scrollable = true;
        while (!moduleSolved)
        {
            bottomText.text = shuffledLyrics[lyricIndex];
            if (submittedText[lyricIndex + 1 > 4 ? 0 : lyricIndex + 1])
            {
                bottomText.color = new Color(0f, 1f, 0f, 1f);
            }
            else
            {
                bottomText.color = new Color(1f, 1f, 1f, 1f);
            }
            lyricIndex++;
            lyricIndex %= 5;
            bottomTextMovement.localPosition = bottomPos;
            float posZ = bottomTextMovement.localPosition.z;
            float posY = bottomTextMovement.localPosition.y;
            while (posZ <= 0.09f)
            {
                posZ += 0.001f;
                bottomTextMovement.localPosition = new Vector3(0f, posY, posZ);
                float speed = 0.02f * upScrollSpeed;
                yield return new WaitForSecondsRealtime(speed);
            }
        }
    }

    void upScrollHandler()
    {
        if (!moduleSolved && scrollable)
        {
            upScrollSpeed = 0.000001f;
            audioRef = audio.PlaySoundAtTransformWithRef("Fast Forward", transform);
            scrolling = true;
        }
    }

    void release()
    {
        upScrollSpeed = 1f;
        scrolling = false;
        if (audioRef != null && audioRef.StopSound != null)
        {
            audioRef.StopSound();
        }

    }
    void submitHandler()
    {
        if (submittable)
        {
            submittable = false;
            float top = topTextMovement.localPosition.z;
            float bottom = bottomTextMovement.localPosition.z;
            Debug.LogFormat("[Dot #{0}] Submit button pressed, selected lyric is {1}", moduleId, selectedLyric);
            if (selectedLyric == chosenLyrics[lyricsSubmitted] && !submittedText[lyricIndex])
            {
                audio.PlaySoundAtTransform("Correct", transform);
                submittedText[lyricIndex] = true; 
                lyricsSubmitted++;
                if (top > bottom)
                {
                    bottomText.color = new Color(0f, 1f, 0f, 1f);
                }
                else
                {
                    topText.color = new Color(0f, 1f, 0f, 1f);
                }   
                Debug.LogFormat("[Dot #{0}] That is correct!", moduleId);
                submittable = true;
                if (lyricsSubmitted >= 5)
                {
                    module.HandlePass();
                    moduleSolved = true;
                    submittable = false;
                    Debug.LogFormat("[Dot #{0}] All five lyrics have been submitted correctly, module solved.", moduleId);
                    string song = "Song " + (chosenSong + 1).ToString();
                    audio.PlaySoundAtTransform(song, transform);
                    StartCoroutine("SolveAnim");
                }
            }
            else
            {
                if (submittedText[lyricIndex])
                {
                    audio.PlaySoundAtTransform("Correct", transform);
                    submittable = true;
                }
                else
                {
                    module.HandleStrike();
                    audio.PlaySoundAtTransform("Wrong", transform);
                    Debug.LogFormat("[Dot #{0}] But that is wrong, strike!", moduleId);
                    StartCoroutine("StrikeAnim");
                }
            }
        }
    }

    IEnumerator StrikeAnim()
    {
        float top = topTextMovement.localPosition.z;
        float bottom = bottomTextMovement.localPosition.z;
        if (top > bottom)
        {
            bottomText.color = new Color(1f, 0f, 0f, 1f);
        }
        else
        {
            topText.color = new Color(1f, 0f, 0f, 1f);
        }
        yield return new WaitForSecondsRealtime(1f);
        if (top > bottom)
        {
            bottomText.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            topText.color = new Color(1f, 1f, 1f, 1f);
        }
        submittable = true;
        yield return null;
    }

    IEnumerator SolveAnim()
    {
        StopCoroutine("topCycleHandler");
        StopCoroutine("bottomCycleHandler");
        float topZ = topTextMovement.localPosition.z;
        float bottomZ = bottomTextMovement.localPosition.z;
        while (topZ <= 0.09f && bottomZ <= 0.09f)
        {
            topZ += 0.001f;
            bottomZ += 0.001f;
            topTextMovement.localPosition = new Vector3(0f, 0.015f, topZ);
            bottomTextMovement.localPosition = new Vector3(0f, 0.015f, bottomZ);
            yield return new WaitForSecondsRealtime(0.03f);
        }
        if (topZ > 0.09f)
        {
            topTextMovement.localPosition = bottomPos;
            topZ = topTextMovement.localPosition.z;     
            topText.text = "全てあなたの所為です。";
            while (topZ < 0f)
            {
                if (topZ < 0f)
                {
                    topZ += 0.001f;
                    topTextMovement.localPosition = new Vector3(0f, 0.015f, topZ);
                }
                if (bottomZ < 0.09f)
                {
                    bottomZ += 0.001f;
                    bottomTextMovement.localPosition = new Vector3(0f, 0.015f, bottomZ);
                }
                yield return new WaitForSecondsRealtime(0.03f);
            }
            while (bottomZ < 0.1f)
            {
                bottomZ += 0.001f;
                bottomTextMovement.localPosition = new Vector3(0f, 0.015f, bottomZ);
                yield return new WaitForSecondsRealtime(0.03f);
            }
        }
        else if (bottomZ > 0.09f)
        {
            bottomTextMovement.localPosition = bottomPos;
            bottomZ = bottomTextMovement.localPosition.z;
            bottomText.text = "全てあなたの所為です。";
            while (bottomZ < 0f)
            {
                if (bottomZ < 0f)
                {
                    bottomZ += 0.001f;
                    bottomTextMovement.localPosition = new Vector3(0f, 0.015f, bottomZ);
                }
                if (topZ < 0.09f)
                {
                    topZ += 0.001f;
                    topTextMovement.localPosition = new Vector3(0f, 0.015f, topZ);
                }
                yield return new WaitForSecondsRealtime(0.03f);
            }
            while (topZ < 0.1f)
            {
                topZ += 0.001f;
                topTextMovement.localPosition = new Vector3(0f, 0.015f, topZ);
                yield return new WaitForSecondsRealtime(0.03f);
            }
        }
        yield return null;
    }

    void Update()
    {
        if (!moduleSolved)
        {
            float top = topTextMovement.localPosition.z;
            float bottom = bottomTextMovement.localPosition.z;
            if (top > bottom)
            {
                selectedLyric = bottomText.text;
            }
            else if (bottom > top)
            {
                selectedLyric = topText.text;
            }
        }
    }
    //Twitch Plays
#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} scroll 5 to hold the scroll button for 5 seconds, !{0} submit [lyric] to submit [lyric] when it displays on the module, !{0} submit to press the submit button";
#pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string command)
    {
        string[] parameters = command.Split(' ');
        Match m;
        if ((m = Regex.Match(command.Trim().ToLowerInvariant(), "scroll (\\d{1,2})")).Success)
        {
            float c;
            if (!float.TryParse(m.Groups[1].Value, out c))
                yield break;
            yield return null;
            upScroll.OnInteract();
            yield return new WaitForSecondsRealtime(c);
            upScroll.OnInteractEnded();
        }
        else if (Regex.IsMatch(command, @"^\s*submit\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return null;
            submit.OnInteract();
        }
        else if (Regex.IsMatch(parameters[0], @"^\s*submit\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return null;
            string l = "";
            for (int i = 1; i < parameters.Length; i++)
            {
                if (i == 1)
                {
                    l = parameters[i];
                }
                else
                {
                    l = l + "　" + parameters[i];
                }
            }
            bool check = false;
            foreach (string k in chosenLyrics)
            {
                if (l == k)
                {
                    check = true;
                }
            }
            if (check)
            {
                upScroll.OnInteract();
                while (true)
                {
                    if (l == selectedLyric)
                    {
                        upScroll.OnInteractEnded(); 
                        submit.OnInteract();                        
                        yield break;
                    }
                    else
                    {
                        yield return null;
                    }
                }
            }
            else
            {
                yield return "sendtochaterror You're trying to submit a lyric not present at all in the module.";
                yield break;
            }
        }

    }

    IEnumerator TwitchHandleForcedSolve()
    {
        upScroll.OnInteract();
        while (!moduleSolved)
        {
            if (chosenLyrics[lyricsSubmitted] == selectedLyric)
            {
                upScroll.OnInteractEnded();
                submit.OnInteract();
                upScroll.OnInteract();
            }
            yield return null;
        }
    }
}
