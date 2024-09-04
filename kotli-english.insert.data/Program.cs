using kotli_english.Entities.Schemes;
using kotli_english.Repositories;
using kotli_english.Repositories.Interfaces;
using kotli_english.Services;
using Microsoft.AspNetCore.Components;

IWordRepository repository = new WordRepository(new FirebaseClientService());
string csv1 = $@"word,meaning,part_of_speech,example_sentence,translation
achievement,達成,noun,Winning the award was a significant achievement.,賞を受賞することは重要な達成でした。
agreement,協定、合意,noun,They reached an agreement after long negotiations.,長い交渉の末、彼らは合意に達しました。
analysis,分析,noun,The analysis showed a significant increase in sales.,分析により、売上の大幅な増加が示されました。
appointment,予約、任命,noun,I have a doctor's appointment tomorrow.,明日は医者の予約があります。
assistance,支援,noun,She received assistance from her colleagues.,彼女は同僚から支援を受けました。
balance,バランス、残高,noun,He checked his bank balance online.,彼はオンラインで銀行残高を確認しました。
benefit,利益、恩恵,noun,The new policy has many benefits for employees.,新しい方針は従業員に多くの利益をもたらします。
budget,予算,noun,The project was completed under budget.,プロジェクトは予算内で完了しました。
candidate,候補者,noun,He is a strong candidate for the position.,彼はその職に適した有力な候補者です。
challenge,挑戦、課題,noun,The team faced several challenges during the project.,チームはプロジェクト中にいくつかの課題に直面しました。
committee,委員会,noun,The committee will review the proposal.,委員会は提案を検討します。
communication,コミュニケーション、伝達,noun,Effective communication is key to teamwork.,効果的なコミュニケーションはチームワークの鍵です。
competition,競争,noun,There is a lot of competition in the market.,市場には多くの競争があります。
complaint,苦情,noun,The company received several complaints about the product.,その会社は製品についていくつかの苦情を受けました。
confidence,自信,noun,She has a lot of confidence in her abilities.,彼女は自分の能力に大きな自信を持っています。
contract,契約,noun,They signed a contract to start the project.,彼らはプロジェクトを開始するために契約を結びました。
contribution,貢献,noun,His contribution to the project was invaluable.,彼のプロジェクトへの貢献は非常に貴重でした。
cost,費用,noun,The total cost of the project was higher than expected.,プロジェクトの総費用は予想以上に高かったです。
decision,決定,noun,The manager made a quick decision.,マネージャーは迅速に決定を下しました。
delivery,配達、配送,noun,The delivery was delayed due to bad weather.,悪天候のため、配達が遅れました。
development,開発、発展,noun,The company is focused on product development.,その会社は製品開発に注力しています。
discussion,議論、討論,noun,They had a long discussion about the project.,彼らはプロジェクトについて長い議論を交わしました。
employee,従業員,noun,The company has over 1,000 employees.,その会社には1,000人以上の従業員がいます。
equipment,設備、装備,noun,The gym has all the latest equipment.,ジムには最新の設備が揃っています。
estimate,見積もり,noun,The estimate for the repair was higher than expected.,修理の見積もりは予想よりも高かったです。
experience,経験,noun,She has a lot of experience in marketing.,彼女はマーケティングに豊富な経験があります。
expense,費用,noun,The trip was a business expense.,その旅行はビジネス費用でした。
goal,目標,noun,Her goal is to become a manager.,彼女の目標はマネージャーになることです。
growth,成長,noun,The company has seen rapid growth over the past year.,その会社は過去1年間で急速な成長を遂げました。
improvement,改善,noun,There has been a significant improvement in sales.,売上に大幅な改善が見られました。
income,収入,noun,His income has increased over the past few years.,彼の収入はここ数年で増加しました。
influence,影響,noun,His ideas have a big influence on the team.,彼のアイデアはチームに大きな影響を与えています。
investment,投資,noun,The company made a large investment in new technology.,その会社は新しい技術に大きな投資を行いました。
issue,問題、課題,noun,The issue was resolved quickly.,問題はすぐに解決されました。
knowledge,知識,noun,He has extensive knowledge of the industry.,彼はその業界に広範な知識を持っています。
labor,労働,noun,The company outsourced its labor to reduce costs.,その会社はコスト削減のために労働を外部委託しました。
limit,限界,noun,There is a limit to how much you can carry.,持ち運べる量には限界があります。
management,管理、経営,noun,Effective management is key to the success of the company.,効果的な管理が会社の成功の鍵です。
market,市場,noun,The company is expanding into the Asian market.,その会社はアジア市場に進出しています。
objective,目的、目標,noun,The main objective of the project is to improve efficiency.,プロジェクトの主な目的は効率を改善することです。
opinion,意見,noun,He has a different opinion on the matter.,彼はその件について異なる意見を持っています。
opportunity,機会,noun,This job is a great opportunity for career growth.,この仕事はキャリア成長のための素晴らしい機会です。
order,注文,noun,We received a large order from the client.,クライアントから大口注文を受けました。
organization,組織,noun,She works for a non-profit organization.,彼女は非営利組織で働いています。
payment,支払い,noun,The payment was processed successfully.,支払いは無事に処理されました。
performance,業績、パフォーマンス,noun,The company's performance improved this quarter.,この四半期の会社の業績は改善しました。
position,職、地位,noun,She was promoted to a managerial position.,彼女は管理職に昇進しました。
price,価格,noun,The price of oil has been rising.,原油価格が上昇しています。
process,過程、プロセス,noun,The hiring process took longer than expected.,採用過程は予想よりも時間がかかりました。";
// await InsertAsync(csv1);

async Task InsertAsync(string csv)
{
    string[] rows = csv.Split(Environment.NewLine);
    foreach (string row in rows)
    {
        string[] cols = row.Split(',');
        Words words = new Words(
            Guid.NewGuid(),
            cols[0],
            cols[1],
            cols[2],
            cols[3],
            cols[4]);
        await repository.AddWordAsync(words);
    }
}