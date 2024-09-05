using Firebase.Database.Query;
using kotli_english.Entities.Schemes;
using kotli_english.Repositories;
using kotli_english.Repositories.Interfaces;
using kotli_english.Services;
using Microsoft.AspNetCore.Components;

string csv1 = $@"achievement,達成,noun,Winning the award was a significant achievement.,賞を受賞することは重要な達成でした。
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
string csv2 = $@"priority,優先事項,noun,Safety is our top priority.,安全が最優先事項です。
procedure,手順,noun,The procedure for applying for a visa is complicated.,ビザの申請手続きは複雑です。
production,生産,noun,The factory increased its production of cars.,工場は車の生産量を増やしました。
proposal,提案,noun,The proposal was accepted by the board.,提案は取締役会によって承認されました。
purchase,購入,noun,She made a large purchase online.,彼女はオンラインで大量に購入しました。
rate,割合、料金,noun,The interest rate on the loan is very high.,ローンの利率は非常に高いです。
recommendation,推薦,noun,She gave a strong recommendation for the job candidate.,彼女はその候補者に強い推薦を与えました。
refund,返金,noun,I received a refund for the defective product.,不良品に対する返金を受け取りました。
relation,関係,noun,The relation between the two companies is strong.,両社の関係は強固です。
request,依頼、要求,noun,They submitted a request for more information.,彼らはさらなる情報を求める要求を提出しました。
reservation,予約,noun,I made a reservation at the restaurant.,私はそのレストランの予約をしました。
resource,資源,noun,The company needs more resources to complete the project.,会社はプロジェクトを完了するためにより多くの資源を必要としています。
response,応答、反応,noun,His response to the question was quick and accurate.,彼の質問への応答は迅速で正確でした。
responsibility,責任,noun,It's your responsibility to complete the task on time.,期限内にタスクを完了するのはあなたの責任です。
result,結果,noun,The result of the meeting was positive.,会議の結果は良好でした。
revenue,収益,noun,The company's revenue increased by 20% last year.,昨年、会社の収益は20%増加しました。
risk,リスク,noun,There is a high risk of failure with this strategy.,この戦略には失敗のリスクが高いです。
role,役割,noun,His role in the project is very important.,彼のプロジェクトにおける役割は非常に重要です。
salary,給料,noun,He earns a good salary at his new job.,彼は新しい仕事で高給を得ています。
schedule,スケジュール,noun,The project is behind schedule.,プロジェクトは予定より遅れています。
service,サービス,noun,The restaurant provides excellent service.,そのレストランは素晴らしいサービスを提供します。
solution,解決策,noun,We need to find a solution to this problem.,この問題に対する解決策を見つける必要があります。
standard,基準,noun,The quality of the product meets industry standards.,製品の品質は業界標準を満たしています。
statement,声明,noun,The company issued a statement regarding the issue.,会社はその問題に関する声明を発表しました。
strategy,戦略,noun,Our marketing strategy is focused on social media.,私たちのマーケティング戦略はソーシャルメディアに焦点を当てています。
success,成功,noun,The product launch was a great success.,製品の発売は大成功でした。
suggestion,提案,noun,She made a helpful suggestion during the meeting.,彼女は会議中に役立つ提案をしました。
support,支援,noun,The project received strong support from the management.,プロジェクトは経営陣から強力な支援を受けました。
system,システム,noun,The new system is more efficient than the old one.,新しいシステムは旧システムよりも効率的です。
task,タスク,noun,The task must be completed by the end of the day.,そのタスクは今日中に完了しなければなりません。
team,チーム,noun,Our team is working on a new project.,私たちのチームは新しいプロジェクトに取り組んでいます。
technology,技術,noun,The company is investing in new technology.,その会社は新技術に投資しています。
tension,緊張,noun,There was a lot of tension during the negotiation.,交渉中に多くの緊張がありました。
training,訓練、研修,noun,The company provides training for new employees.,その会社は新入社員に対して研修を行っています。
trend,傾向,noun,The current trend is toward more online shopping.,現在の傾向はオンラインショッピングの増加です。
trial,試み、試験,noun,They are conducting a trial of the new product.,彼らは新製品の試験を行っています。
user,ユーザー,noun,The software is designed to be user-friendly.,そのソフトウェアはユーザーフレンドリーに設計されています。
value,価値,noun,This product offers great value for the price.,この製品は価格に対して非常に良い価値を提供します。
version,バージョン,noun,The latest version of the software has new features.,そのソフトウェアの最新バージョンには新機能が追加されています。
view,見解、意見,noun,His view on the issue is different from mine.,その問題に対する彼の見解は私のものとは異なります。
volume,量、体積,noun,The volume of sales increased last month.,先月、販売量が増加しました。
waste,無駄、廃棄物,noun,We need to reduce the amount of waste produced by the company.,会社で発生する廃棄物を減らす必要があります。";
string csv3 = $@"advantage,利点,noun,He has an advantage due to his experience.,彼は経験があるため有利です。
advertisement,広告,noun,The advertisement was shown on TV last night.,その広告は昨晩テレビで放映されました。
agreement,合意,noun,They reached an agreement after long discussions.,彼らは長時間の議論の末、合意に達しました。
analysis,分析,noun,The analysis showed an increase in sales.,分析の結果、売上の増加が示されました。
application,申請,noun,Her application for the job was accepted.,彼女の仕事の申請が受け入れられました。
appointment,予約,noun,I have a doctor's appointment tomorrow.,明日医者の予約があります。
approach,アプローチ,noun,We need a new approach to solve this problem.,この問題を解決するために新しいアプローチが必要です。
arrival,到着,noun,Her arrival was delayed by the storm.,彼女の到着は嵐のため遅れました。
article,記事,noun,I read an interesting article in the newspaper.,私は新聞で興味深い記事を読みました。
aspect,側面,noun,We need to consider every aspect of the project.,私たちはプロジェクトのあらゆる側面を考慮する必要があります。
assistance,援助,noun,They offered financial assistance to the victims.,彼らは被害者に財政的な援助を提供しました。
attempt,試み,noun,His attempt to break the record failed.,彼の記録を破ろうとする試みは失敗しました。
attention,注意,noun,The speaker caught everyone's attention.,スピーカーは皆の注意を引きました。
attitude,態度,noun,Her attitude towards the project was very positive.,彼女のプロジェクトに対する態度は非常に前向きでした。
author,著者,noun,The author of the book will give a lecture.,その本の著者が講演を行います。
awareness,認識,noun,There is growing awareness of environmental issues.,環境問題に対する認識が高まっています。
balance,バランス,noun,It's important to maintain a balance between work and life.,仕事と生活のバランスを保つことが重要です。
base,基盤,noun,The company is trying to expand its customer base.,会社は顧客基盤を拡大しようとしています。
behavior,行動,noun,His behavior during the meeting was unacceptable.,会議中の彼の行動は受け入れられませんでした。
benefit,利益,noun,The new policy offers many benefits to employees.,新しい方針は従業員に多くの利益をもたらします。
budget,予算,noun,We need to reduce our budget for next year.,来年度の予算を削減する必要があります。
career,キャリア,noun,She is focusing on her career at the moment.,彼女は現在、キャリアに集中しています。
challenge,挑戦,noun,The project is a big challenge for the team.,そのプロジェクトはチームにとって大きな挑戦です。
change,変化,noun,There has been a significant change in the plan.,計画に大きな変化がありました。
choice,選択,noun,You have a choice between two options.,あなたには2つの選択肢があります。
claim,主張,noun,The company made a claim about the effectiveness of its product.,会社は自社製品の効果について主張しました。
collection,収集,noun,She has a large collection of vintage clothes.,彼女はビンテージ服を大量に収集しています。
comment,コメント,noun,He made a comment about the new policy.,彼は新しい方針についてコメントしました。
communication,通信,noun,Good communication is essential for teamwork.,良好なコミュニケーションはチームワークに不可欠です。
competition,競争,noun,The competition in the market is increasing.,市場での競争が激化しています。
complaint,苦情,noun,The customer filed a complaint about the service.,顧客はサービスについて苦情を申し立てました。
conclusion,結論,noun,We reached a conclusion after reviewing the data.,データを見直した後、結論に達しました。
condition,条件,noun,The car is in good condition.,その車は良好な状態です。
conference,会議,noun,The annual conference will be held next month.,年次会議は来月開催されます。
connection,接続,noun,There is a weak connection between the two devices.,2つのデバイスの接続は弱いです。
consequence,結果,noun,The consequences of the decision were unexpected.,その決定の結果は予想外でした。
consideration,考慮,noun,We need to give this issue more consideration.,この問題をさらに考慮する必要があります。
construction,建設,noun,The construction of the new building will begin soon.,新しい建物の建設はまもなく始まります。
consumer,消費者,noun,Consumers are demanding higher quality products.,消費者はより高品質な製品を求めています。
contract,契約,noun,They signed a contract with the supplier.,彼らはサプライヤーとの契約に署名しました。
contribution,貢献,noun,His contribution to the project was invaluable.,彼のプロジェクトへの貢献は非常に貴重でした。
control,制御,noun,The company has tight control over its expenses.,会社は経費を厳重に管理しています。
conversation,会話,noun,We had a long conversation about the issue.,私たちはその問題について長い会話をしました。
cost,費用,noun,The cost of living has increased in recent years.,生活費は近年増加しています。
crisis,危機,noun,The company is facing a financial crisis.,会社は財政危機に直面しています。
culture,文化,noun,She is interested in Japanese culture.,彼女は日本文化に興味があります。
customer,顧客,noun,The company values its loyal customers.,会社は忠実な顧客を大切にしています。
damage,損害,noun,The storm caused significant damage to the building.,嵐は建物に大きな損害を与えました。
data,データ,noun,We need to analyze the data before making a decision.,意思決定前にデータを分析する必要があります。
deadline,締め切り,noun,The project deadline is next Friday.,プロジェクトの締め切りは来週の金曜日です。";
string csv4 = $@"decision,決定,noun,The final decision will be made tomorrow.,最終決定は明日下されます。
delivery,配達,noun,The delivery of the package is scheduled for next week.,荷物の配達は来週の予定です。
demand,需要,noun,There is high demand for electric cars.,電気自動車の需要が高まっています。
department,部門,noun,He works in the marketing department.,彼はマーケティング部門で働いています。
development,発展,noun,The development of new technologies is crucial.,新技術の発展は非常に重要です。
difference,違い,noun,There's a big difference between the two products.,その2つの製品には大きな違いがあります。
difficulty,困難,noun,They faced many difficulties during the project.,彼らはプロジェクト中に多くの困難に直面しました。
direction,方向,noun,Please follow the directions on the map.,地図の指示に従ってください。
discussion,討論,noun,We had a long discussion about the budget.,私たちは予算について長い討論をしました。
distribution,分配,noun,The distribution of resources was uneven.,資源の分配は不均等でした。
document,文書,noun,Please submit the required documents by Friday.,必要な文書を金曜日までに提出してください。
effect,効果,noun,The new law had a positive effect on the economy.,新しい法律は経済に良い効果をもたらしました。
effort,努力,noun,She put a lot of effort into the project.,彼女はそのプロジェクトに多くの努力を注ぎました。
employee,従業員,noun,The company hired 10 new employees this month.,会社は今月10人の新しい従業員を雇いました。
energy,エネルギー,noun,We need to focus on renewable energy sources.,再生可能エネルギー源に注目する必要があります。
equipment,装置、設備,noun,The gym has new exercise equipment.,そのジムには新しい運動装置があります。
estimate,見積もり,noun,The estimate for the project was higher than expected.,プロジェクトの見積もりは予想より高かったです。
event,出来事、イベント,noun,The company is hosting a major event next month.,会社は来月大きなイベントを開催します。
evidence,証拠,noun,There is no evidence to support the claim.,その主張を裏付ける証拠はありません。
example,例,noun,This is a good example of teamwork.,これはチームワークの良い例です。
exchange,交換,noun,We had a friendly exchange of ideas during the meeting.,会議中に友好的な意見交換を行いました。
experience,経験,noun,She has five years of experience in marketing.,彼女はマーケティングで5年の経験があります。
expense,費用,noun,The company is trying to reduce its expenses.,会社は経費を削減しようとしています。
expert,専門家,noun,We need to consult with an expert on this issue.,この問題について専門家に相談する必要があります。
export,輸出,noun,The country relies heavily on the export of oil.,その国は石油の輸出に大きく依存しています。
factor,要因,noun,Price is an important factor in consumer decisions.,価格は消費者の決定において重要な要因です。
failure,失敗,noun,The project was a failure due to poor planning.,そのプロジェクトは計画不足のため失敗しました。
feature,特徴,noun,The phone has several new features.,その電話にはいくつかの新しい機能があります。
feedback,フィードバック,noun,We received positive feedback from our customers.,顧客から良いフィードバックを受け取りました。
goal,目標,noun,Our goal is to increase sales by 10% this year.,私たちの目標は今年売上を10%増加させることです。
growth,成長,noun,The company has seen steady growth in profits.,会社は利益の安定した成長を見ています。
impact,影響,noun,The new regulations had a major impact on the industry.,新しい規制は業界に大きな影響を与えました。
importance,重要性,noun,We cannot ignore the importance of customer satisfaction.,顧客満足の重要性を無視することはできません。
improvement,改善,noun,We noticed a significant improvement in performance.,私たちはパフォーマンスの大幅な改善に気付きました。
income,収入,noun,His income has increased over the past few years.,彼の収入は過去数年間で増加しています。
industry,産業,noun,The technology industry is rapidly evolving.,技術産業は急速に進化しています。
influence,影響,noun,Her speech had a strong influence on the audience.,彼女の演説は聴衆に強い影響を与えました。
information,情報,noun,We need more information to make a decision.,意思決定をするためにはもっと情報が必要です。
initiative,主導権、イニシアチブ,noun,She took the initiative to organize the meeting.,彼女は会議を主導して開催しました。
inspection,検査,noun,The building passed the safety inspection.,その建物は安全検査に合格しました。
investment,投資,noun,They made a significant investment in renewable energy.,彼らは再生可能エネルギーに大規模な投資を行いました。
issue,問題,noun,The issue was discussed in the meeting.,その問題は会議で議論されました。
knowledge,知識,noun,He has extensive knowledge of computer programming.,彼はコンピュータープログラミングに関する広範な知識を持っています。
labor,労働,noun,The cost of labor has increased in recent years.,労働コストは近年上昇しています。
limit,限界,noun,There is a limit to how much we can spend on this project.,このプロジェクトに使える金額には限界があります。
loss,損失,noun,The company reported a significant loss last quarter.,会社は前四半期に大きな損失を報告しました。
management,経営、管理,noun,Effective management is crucial for business success.,効果的な経営はビジネスの成功に不可欠です。
market,市場,noun,The company is trying to expand into new markets.,会社は新しい市場への拡大を目指しています。
material,材料、資料,noun,We need more materials for the construction.,建設のためにもっと材料が必要です。";
string csv5 = $@"method,方法,noun,They developed a new method for processing data.,彼らはデータ処理のための新しい方法を開発しました。
mistake,間違い,noun,He made a mistake in the calculations.,彼は計算で間違いをしました。
motivation,動機,noun,Her motivation to succeed is very strong.,彼女の成功への動機は非常に強いです。
network,ネットワーク,noun,The company has a vast network of partners.,その会社は広範なパートナーネットワークを持っています。
opinion,意見,noun,He expressed his opinion about the project.,彼はプロジェクトに対する意見を述べました。
opportunity,機会,noun,This job offers many opportunities for growth.,この仕事は多くの成長の機会を提供します。
option,選択肢,noun,You have two options to choose from.,2つの選択肢があります。
order,注文,noun,We placed an order for new office supplies.,私たちは新しいオフィス用品を注文しました。
organization,組織,noun,The organization helps homeless people.,その組織はホームレスの人々を支援しています。
participant,参加者,noun,All participants must register before the event.,すべての参加者はイベント前に登録しなければなりません。
partnership,提携,noun,The partnership between the two companies was successful.,2社間の提携は成功しました。
payment,支払い,noun,The payment for the service was processed online.,サービスの支払いはオンラインで処理されました。
performance,業績,noun,Her performance in the play was outstanding.,彼女の劇での演技は素晴らしかったです。
period,期間,noun,The warranty is valid for a period of one year.,保証は1年間有効です。
permission,許可,noun,We need permission to enter the restricted area.,制限区域に入るには許可が必要です。
personality,個性,noun,She has a very outgoing personality.,彼女は非常に社交的な性格です。
policy,方針,noun,The company has a strict policy on privacy.,その会社にはプライバシーに関する厳しい方針があります。
position,立場、位置,noun,She was promoted to a higher position.,彼女はより高い役職に昇進しました。
possibility,可能性,noun,There is a possibility of rain tomorrow.,明日雨が降る可能性があります。
potential,潜在能力,noun,He has the potential to become a great leader.,彼には偉大なリーダーになる潜在能力があります。
practice,実践、練習,noun,Regular practice is important for improvement.,定期的な練習は向上のために重要です。
preference,好み,noun,She has a preference for classical music.,彼女はクラシック音楽を好みます。
preparation,準備,noun,Preparation for the meeting took several hours.,会議の準備に数時間かかりました。
price,価格,noun,The price of the product has increased.,製品の価格が上がりました。
priority,優先事項,noun,Safety is our top priority.,安全が私たちの最優先事項です。
problem,問題,noun,We need to find a solution to this problem.,この問題の解決策を見つける必要があります。
process,過程,noun,The hiring process took longer than expected.,採用プロセスは予想よりも長くかかりました。
product,製品,noun,The company launched a new product last month.,その会社は先月新しい製品を発売しました。
profit,利益,noun,The company reported a large profit this quarter.,会社は今四半期に大きな利益を報告しました。
progress,進捗,noun,We are making good progress on the project.,プロジェクトは順調に進んでいます。
project,プロジェクト,noun,The project was completed ahead of schedule.,プロジェクトは予定より早く完了しました。
proposal,提案,noun,He submitted a proposal for the new initiative.,彼は新しいイニシアチブの提案を提出しました。
protection,保護,noun,The new law provides better protection for consumers.,新しい法律は消費者により良い保護を提供します。
purpose,目的,noun,The purpose of the meeting is to discuss the budget.,会議の目的は予算について議論することです。
quality,品質,noun,The quality of the product is excellent.,製品の品質は素晴らしいです。
quantity,数量,noun,We need to order a larger quantity of materials.,私たちはもっと多くの材料を注文する必要があります。
range,範囲,noun,The store offers a wide range of products.,その店は幅広い製品を提供しています。
reason,理由,noun,The reason for the delay was bad weather.,遅延の理由は悪天候でした。
recommendation,推薦,noun,He gave a strong recommendation for the candidate.,彼は候補者を強く推薦しました。
reduction,削減,noun,The company announced a reduction in prices.,その会社は価格の引き下げを発表しました。
reflection,反映、反射,noun,His actions are a reflection of his values.,彼の行動は彼の価値観を反映しています。
relationship,関係,noun,Their relationship improved over time.,彼らの関係は時間とともに改善しました。
replacement,交換,noun,We need to find a replacement for the broken part.,壊れた部品の交換が必要です。
report,報告,noun,The report showed a significant increase in sales.,その報告は売上の大幅な増加を示しました。
requirement,要件,noun,Meeting the requirements is essential for success.,要件を満たすことが成功に不可欠です。
resource,資源,noun,Water is an important natural resource.,水は重要な天然資源です。
response,反応,noun,We received a positive response to the new product.,新しい製品に対して肯定的な反応を受け取りました。
responsibility,責任,noun,It's his responsibility to ensure the project is completed.,プロジェクトが完了することを保証するのは彼の責任です。
result,結果,noun,The test results were better than expected.,テストの結果は予想より良かったです。
revenue,収益,noun,The company's revenue increased by 10% this year.,会社の収益は今年10%増加しました。
risk,リスク,noun,There is a risk of losing money in the stock market.,株式市場でお金を失うリスクがあります。";
string csv6 = $@"role,役割,noun,Her role in the project is critical to its success.,彼女のプロジェクトにおける役割は成功に不可欠です。
rule,規則,noun,The company has strict rules about workplace behavior.,会社には職場の行動に関する厳しい規則があります。
salary,給料,noun,He received a raise in his salary last month.,彼は先月給料の昇給を受けました。
sample,サンプル,noun,The store gave out free samples of their new product.,その店は新しい製品の無料サンプルを配っていました。
schedule,予定,noun,The schedule for the meeting was changed.,会議の予定が変更されました。
security,安全,noun,The airport has increased its security measures.,空港は安全対策を強化しました。
selection,選択,noun,The selection of books in the library is excellent.,図書館の本の選択は素晴らしいです。
service,サービス,noun,The company offers excellent customer service.,その会社は優れた顧客サービスを提供しています。
shift,シフト,noun,She works the night shift at the hospital.,彼女は病院で夜勤をしています。
significance,重要性,noun,The significance of the discovery cannot be overstated.,その発見の重要性は言い過ぎることはありません。
skill,スキル,noun,He has excellent communication skills.,彼は優れたコミュニケーションスキルを持っています。
solution,解決策,noun,We need to find a solution to the problem.,私たちは問題の解決策を見つける必要があります。
source,源,noun,The source of the information is confidential.,情報の出所は秘密です。
staff,スタッフ,noun,The hospital has a highly trained medical staff.,その病院には高度に訓練された医療スタッフがいます。
standard,基準,noun,We need to maintain high standards of quality.,私たちは高い品質基準を維持する必要があります。
statement,声明,noun,The CEO issued a statement regarding the company's performance.,CEOは会社の業績に関する声明を発表しました。
strategy,戦略,noun,Their marketing strategy helped increase sales.,彼らのマーケティング戦略は売上増加に役立ちました。
strength,強さ,noun,His physical strength is impressive.,彼の体力は見事です。
structure,構造,noun,The structure of the organization is complex.,その組織の構造は複雑です。
success,成功,noun,The success of the project depends on teamwork.,プロジェクトの成功はチームワークにかかっています。
suggestion,提案,noun,She made a suggestion to improve the process.,彼女はプロセスを改善するための提案をしました。
support,支援,noun,We need more support from management.,私たちは経営陣からもっと支援が必要です。
survey,調査,noun,The survey results showed high customer satisfaction.,調査結果は顧客満足度が高いことを示しました。
system,システム,noun,The company is upgrading its computer systems.,会社はコンピューターシステムをアップグレードしています。
task,課題,noun,The task was completed ahead of schedule.,その課題は予定より早く完了しました。
technology,技術,noun,Advances in technology are changing the world.,技術の進歩は世界を変えています。
term,用語,noun,You need to understand the terms of the contract.,契約の用語を理解する必要があります。
theory,理論,noun,The theory has been widely accepted by scientists.,その理論は科学者たちに広く受け入れられています。
tool,道具,noun,We use a variety of tools for this job.,この仕事にはさまざまな道具を使います。
topic,話題,noun,The topic of the discussion was climate change.,議論の話題は気候変動でした。
tradition,伝統,noun,The family follows a long tradition of farming.,その家族は長い農業の伝統を守っています。
training,訓練,noun,The employees received training on the new software.,従業員は新しいソフトウェアの訓練を受けました。
transaction,取引,noun,The transaction was completed online.,取引はオンラインで完了しました。
transportation,交通,noun,Public transportation is widely used in the city.,その都市では公共交通機関が広く利用されています。
trend,傾向,noun,There is a growing trend towards remote work.,リモートワークへの傾向が高まっています。
trouble,問題,noun,We are having trouble with the new system.,新しいシステムで問題が発生しています。
trust,信頼,noun,Trust is essential in any business relationship.,信頼はビジネス関係において不可欠です。
truth,真実,noun,It's important to tell the truth in all situations.,すべての状況で真実を語ることが重要です。
understanding,理解,noun,We have a mutual understanding of the goals.,私たちは目標に対する相互理解があります。
value,価値,noun,The value of the property has increased.,その物件の価値は上がりました。
variety,多様性,noun,The store offers a wide variety of products.,その店は多様な製品を提供しています。
version,バージョン,noun,The software is available in several versions.,そのソフトウェアはいくつかのバージョンで提供されています。
victory,勝利,noun,The team celebrated their victory in the tournament.,チームはトーナメントでの勝利を祝いました。
view,眺め、意見,noun,The view from the top of the mountain is breathtaking.,山頂からの眺めは息をのむほどです。
vision,ビジョン、視覚,noun,He has a clear vision for the future of the company.,彼は会社の未来に対して明確なビジョンを持っています。
volume,音量、量,noun,The volume of traffic has increased during rush hour.,ラッシュアワー中の交通量が増加しました。
warning,警告,noun,We received a warning about the approaching storm.,接近中の嵐について警告を受けました。
waste,浪費、廃棄物,noun,The company is working to reduce waste.,会社は廃棄物を減らすために取り組んでいます。
wealth,富,noun,He built his wealth through smart investments.,彼は賢明な投資によって富を築きました。
weather,天気,noun,The weather is expected to be sunny tomorrow.,明日の天気は晴れの予想です。";
string csv7 = $@"accident,事故,noun,The accident caused a major traffic jam.,その事故は大きな交通渋滞を引き起こしました。
account,口座,noun,She opened a new bank account last week.,彼女は先週新しい銀行口座を開設しました。
advice,助言,noun,He gave me some good advice on how to handle the situation.,彼はその状況をどのように処理するかについて良い助言をしてくれました。
affair,事件,noun,The political affair shocked the nation.,その政治的事件は国を驚かせました。
agent,代理人,noun,She works as a real estate agent.,彼女は不動産代理人として働いています。
agreement,合意,noun,They reached an agreement after several hours of negotiation.,彼らは数時間の交渉の末、合意に達しました。
aim,目標,noun,The aim of this project is to improve efficiency.,このプロジェクトの目標は効率を向上させることです。
ambition,野望,noun,His ambition is to become a successful entrepreneur.,彼の野望は成功した起業家になることです。
analysis,分析,noun,The analysis of the data took several days.,データの分析に数日かかりました。
announcement,発表,noun,The company made an important announcement today.,会社は今日重要な発表をしました。
appointment,予約,noun,I have a dentist appointment tomorrow afternoon.,明日の午後、歯医者の予約があります。
argument,議論,noun,They had an argument about the best way to solve the problem.,彼らは問題を解決する最良の方法について議論しました。
arrival,到着,noun,His arrival was delayed due to bad weather.,彼の到着は悪天候のため遅れました。
aspect,側面,noun,We need to consider every aspect of the project.,プロジェクトのあらゆる側面を考慮する必要があります。
assistance,支援,noun,He asked for assistance with his work.,彼は仕事に関して支援を求めました。
attempt,試み,noun,Her attempt to climb the mountain was successful.,彼女の山登りの試みは成功しました。
attitude,態度,noun,Her positive attitude helped her overcome the difficulties.,彼女の前向きな態度が困難を乗り越える助けとなりました。
authority,権限,noun,The police have the authority to make arrests.,警察は逮捕する権限を持っています。
background,背景,noun,He has a background in engineering.,彼は工学のバックグラウンドを持っています。
balance,バランス,noun,It's important to maintain a work-life balance.,仕事と生活のバランスを保つことが重要です。
basis,基礎,noun,The theory is based on a solid scientific basis.,その理論は確固たる科学的基礎に基づいています。
behavior,行動,noun,The child's behavior improved after counseling.,その子供の行動はカウンセリング後に改善しました。
belief,信念,noun,He has a strong belief in hard work.,彼は勤勉に対する強い信念を持っています。
benefit,利益,noun,The new policy offers many benefits to employees.,新しい政策は従業員に多くの利益をもたらします。
budget,予算,noun,We need to plan the project within the allocated budget.,割り当てられた予算内でプロジェクトを計画する必要があります。
business,ビジネス,noun,She started her own business last year.,彼女は昨年自分のビジネスを始めました。
capacity,容量,noun,The factory is running at full capacity.,工場はフル稼働しています。
challenge,挑戦,noun,This new job is a big challenge for me.,この新しい仕事は私にとって大きな挑戦です。
chance,機会,noun,There's a good chance it will rain tomorrow.,明日雨が降る可能性が高いです。
choice,選択,noun,You have a choice between these two options.,あなたにはこの2つの選択肢があります。
circumstance,状況,noun,Under normal circumstances, we would have finished the project by now.,通常の状況では、私たちは今頃プロジェクトを終えていたでしょう。
claim,主張,noun,He made a claim about his innocence.,彼は自分の無実を主張しました。
client,顧客,noun,Our firm has many international clients.,私たちの会社には多くの国際的な顧客がいます。
committee,委員会,noun,The committee will meet to discuss the new policy.,委員会は新しい政策について話し合うために集まります。
communication,コミュニケーション,noun,Good communication is key to successful teamwork.,良好なコミュニケーションは成功したチームワークの鍵です。
comparison,比較,noun,The comparison between the two products shows clear differences.,2つの製品の比較は明らかな違いを示しています。
competition,競争,noun,The competition between the companies is intense.,その会社間の競争は激しいです。
complaint,苦情,noun,He filed a complaint about the poor service.,彼はひどいサービスについて苦情を申し立てました。
conclusion,結論,noun,They reached the conclusion after a long discussion.,彼らは長い議論の末、結論に達しました。
condition,条件,noun,The car is in excellent condition.,その車は素晴らしい状態です。
conference,会議,noun,The annual conference will be held in New York.,毎年恒例の会議がニューヨークで開催されます。
confidence,自信,noun,She has a lot of confidence in her abilities.,彼女は自分の能力に大いに自信を持っています。
conflict,対立,noun,There was a conflict between the two teams.,2つのチームの間で対立がありました。
consequence,結果,noun,The consequences of the decision were unexpected.,その決定の結果は予想外でした。
consideration,考慮,noun,We need to give careful consideration to all options.,すべての選択肢を慎重に考慮する必要があります。
construction,建設,noun,The construction of the new building will begin next month.,新しい建物の建設は来月から始まります。
consultation,相談,noun,He had a consultation with a lawyer about the case.,彼はその事件について弁護士と相談しました。
consumer,消費者,noun,The company is focused on consumer satisfaction.,その会社は消費者の満足に注力しています。
context,文脈,noun,The meaning of the word changes depending on the context.,その単語の意味は文脈によって変わります。
contract,契約,noun,We signed a contract with a new supplier.,私たちは新しい供給業者と契約を結びました。
contribution,貢献,noun,Her contribution to the project was invaluable.,彼女のプロジェクトへの貢献は非常に貴重でした。";
string csv8 = $@"accept,受け入れる,verb,He accepted the job offer without hesitation.,彼はためらうことなくその仕事のオファーを受け入れました。
achieve,達成する,verb,She achieved her goal of becoming a doctor.,彼女は医者になるという目標を達成しました。
add,加える,verb,Please add your name to the list.,リストにあなたの名前を加えてください。
afford,余裕がある,verb,I can't afford to buy a new car right now.,私は今、新しい車を買う余裕がありません。
agree,同意する,verb,We agreed to meet at 6 PM.,私たちは午後6時に会うことに同意しました。
allow,許可する,verb,The teacher allowed the students to leave early.,先生は生徒たちに早く帰ることを許可しました。
analyze,分析する,verb,We need to analyze the data before making a decision.,決定を下す前にデータを分析する必要があります。
announce,発表する,verb,The company announced its new product line.,会社は新しい製品ラインを発表しました。
apply,適用する,verb,He applied for a job at the company.,彼はその会社に仕事を応募しました。
approve,承認する,verb,The manager approved the budget for the project.,マネージャーはプロジェクトの予算を承認しました。
argue,議論する,verb,They argued about the best way to solve the problem.,彼らは問題を解決する最良の方法について議論しました。
arrange,手配する,verb,She arranged a meeting with her boss.,彼女は上司との会議を手配しました。
arrive,到着する,verb,The train arrived on time.,電車は定刻に到着しました。
ask,尋ねる,verb,She asked me if I wanted to join her for lunch.,彼女は私に昼食に参加したいかどうか尋ねました。
assist,支援する,verb,We assisted the customers with their purchases.,私たちは顧客の購入を支援しました。
assume,仮定する,verb,I assume he will be here by noon.,私は彼が正午までにここにいるだろうと仮定しています。
attend,出席する,verb,She attended the conference in Tokyo.,彼女は東京での会議に出席しました。
avoid,避ける,verb,He avoided answering the question directly.,彼はその質問に直接答えることを避けました。
believe,信じる,verb,I believe in the importance of hard work.,私は勤勉の重要性を信じています。
belong,属する,verb,This book belongs to me.,この本は私のものです。
blame,非難する,verb,They blamed the manager for the mistake.,彼らはそのミスをマネージャーのせいにしました。
build,建てる,verb,They plan to build a new office building.,彼らは新しいオフィスビルを建てる予定です。
cancel,キャンセルする,verb,We had to cancel the meeting due to bad weather.,悪天候のため、会議をキャンセルしなければなりませんでした。
celebrate,祝う,verb,They celebrated their anniversary last weekend.,彼らは先週末に記念日を祝いました。
change,変える,verb,He changed his mind about the trip.,彼はその旅行について考えを変えました。
choose,選ぶ,verb,We need to choose the best candidate for the job.,私たちはその仕事に最適な候補者を選ばなければなりません。
claim,主張する,verb,She claimed that she was innocent.,彼女は自分が無実だと主張しました。
collect,集める,verb,He collects stamps from all over the world.,彼は世界中から切手を集めています。
communicate,伝える,verb,They communicated their concerns to the management.,彼らは自分たちの懸念を経営陣に伝えました。
compare,比較する,verb,We need to compare the prices of different models.,私たちは異なるモデルの価格を比較する必要があります。
complete,完了する,verb,She completed the project ahead of schedule.,彼女は予定より早くプロジェクトを完了しました。
confirm,確認する,verb,We need to confirm the reservation for dinner.,私たちは夕食の予約を確認する必要があります。
consider,検討する,verb,They are considering moving to a new city.,彼らは新しい都市への引っ越しを検討しています。
continue,続ける,verb,He continued working on the project late into the night.,彼は夜遅くまでプロジェクトに取り組み続けました。
contribute,貢献する,verb,She contributed a lot to the success of the event.,彼女はイベントの成功に大いに貢献しました。
control,制御する,verb,The manager controls the budget for the department.,マネージャーはその部署の予算を管理しています。
convince,納得させる,verb,He convinced his boss to approve the new plan.,彼は上司に新しい計画を承認するよう納得させました。
create,作る,verb,She created a beautiful painting.,彼女は美しい絵を描きました。
decide,決定する,verb,They decided to go on a vacation in August.,彼らは8月に休暇に行くことを決定しました。
deliver,配達する,verb,The package was delivered to my house this morning.,荷物は今朝私の家に配達されました。
demand,要求する,verb,The workers demanded better working conditions.,労働者たちはより良い労働条件を要求しました。
deny,否定する,verb,He denied any involvement in the crime.,彼はその犯罪への関与を否定しました。
describe,説明する,verb,Can you describe what happened at the meeting?,会議で何が起こったのか説明してもらえますか？
design,設計する,verb,She designed the layout for the new website.,彼女は新しいウェブサイトのレイアウトを設計しました。
develop,開発する,verb,The company is developing new software.,その会社は新しいソフトウェアを開発しています。
discover,発見する,verb,They discovered a new species of plant in the rainforest.,彼らは熱帯雨林で新しい植物の種を発見しました。
discuss,話し合う,verb,We need to discuss the details of the proposal.,私たちは提案の詳細について話し合う必要があります。
distribute,配布する,verb,The flyers were distributed throughout the city.,チラシは市内全域に配布されました。
earn,稼ぐ,verb,She earns a good salary at her new job.,彼女は新しい仕事で良い給料を稼いでいます。
encourage,励ます,verb,He encouraged his team to keep working hard.,彼はチームに一生懸命働き続けるよう励ましました。";
string csv9 = $@"achieve,達成する,verb,She achieved her goal of running a marathon,彼女はマラソンを完走するという目標を達成した
adapt,適応する,verb,The company adapted its strategy to meet market demands,会社は市場の要求に応じて戦略を適応させた
analyze,分析する,verb,We need to analyze the data before making a decision,決定を下す前にデータを分析する必要がある
apply,適用する,verb,You should apply these principles to your work,これらの原則を仕事に適用すべきだ
assess,評価する,verb,The team will assess the project's progress next week,チームは来週プロジェクトの進捗を評価する
attain,達成する,verb,She attained a high level of proficiency in French,彼女はフランス語の高いレベルに達成した
benefit,利益を得る,verb,The new policy will benefit all employees,新しい方針は全社員に利益をもたらす
conduct,実施する,verb,The researchers conducted a survey to gather information,研究者たちは情報を集めるために調査を実施した
confirm,確認する,verb,Please confirm your attendance by Friday,金曜日までに出席を確認してください
consider,考慮する,verb,We need to consider all options before making a decision,決定を下す前にすべての選択肢を考慮する必要がある
consult,相談する,verb,I will consult with my team before making the final decision,最終決定を下す前にチームと相談します
create,作成する,verb,The designer created a new logo for the company,デザイナーは会社のために新しいロゴを作成した
deliver,配達する,verb,The courier delivered the package on time,宅配便がパッケージを時間通りに配達した
enhance,強化する,verb,The software update will enhance system performance,ソフトウェアのアップデートはシステムのパフォーマンスを強化する
evaluate,評価する,verb,We need to evaluate the effectiveness of the new policy,新しい方針の効果を評価する必要がある
execute,実行する,verb,They executed the plan flawlessly,彼らは計画を完璧に実行した
expand,拡張する,verb,The company plans to expand into new markets,会社は新しい市場に拡張する計画を立てている
follow,従う,verb,You should follow the instructions carefully,指示に注意深く従うべきです
formulate,策定する,verb,The team formulated a new strategy for growth,チームは成長のための新しい戦略を策定した
improve,改善する,verb,We need to improve our customer service,私たちは顧客サービスを改善する必要がある
implement,実施する,verb,The company will implement the new procedures next month,会社は来月に新しい手順を実施する
influence,影響を与える,verb,Her leadership style influenced the team positively,彼女のリーダーシップスタイルはチームに良い影響を与えた
initiate,開始する,verb,We will initiate the project next week,来週プロジェクトを開始します
integrate,統合する,verb,We need to integrate the new system with the old one,新しいシステムを古いシステムと統合する必要がある
launch,開始する,verb,The company will launch a new product line,会社は新しい製品ラインを開始する
manage,管理する,verb,He manages a team of twenty employees,彼は20人の社員のチームを管理している
monitor,監視する,verb,The IT department monitors network activity,IT部門はネットワークの活動を監視している
negotiate,交渉する,verb,They negotiated a better contract,彼らはより良い契約を交渉した
organize,整理する,verb,She organized the conference efficiently,彼女は会議を効率的に整理した
perform,実行する,verb,The team performed well during the presentation,チームはプレゼンテーション中にうまく実行した
prioritize,優先順位を付ける,verb,We need to prioritize our tasks for the week,今週のタスクに優先順位を付ける必要がある
produce,生産する,verb,The factory produces high-quality goods,工場は高品質な製品を生産する
promote,促進する,verb,The company promotes employee development,会社は社員の育成を促進する
recommend,推奨する,verb,She recommended a new book for the team,彼女はチームに新しい本を推奨した
resolve,解決する,verb,We need to resolve the issue as soon as possible,できるだけ早く問題を解決する必要がある
review,見直す,verb,The manager reviewed the report before the meeting,マネージャーは会議前にレポートを見直した
schedule,予定を立てる,verb,They scheduled the meeting for next Monday,彼らは会議を来週の月曜日に予定した
settle,解決する,verb,We need to settle the dispute quickly,できるだけ早く争いを解決する必要がある
streamline,効率化する,verb,The new software will streamline our processes,新しいソフトウェアはプロセスを効率化する
suggest,提案する,verb,She suggested a different approach to the problem,彼女は問題への別のアプローチを提案した
sustain,維持する,verb,The company aims to sustain its growth,会社は成長を維持することを目指している
track,追跡する,verb,We need to track our progress,進捗を追跡する必要がある
transform,変革する,verb,The company transformed its business model,会社はビジネスモデルを変革した
update,更新する,verb,Please update the file with the latest information,最新の情報でファイルを更新してください
utilize,利用する,verb,We should utilize all available resources,利用可能なすべてのリソースを利用するべきです
verify,確認する,verb,The technician verified the system's functionality,技術者はシステムの機能を確認した
win,勝つ,verb,They won the award for best project,彼らは最優秀プロジェクトの賞を受賞した";
string csv10 = $@"acquire,取得する,verb,The company acquired new technology last year,会社は昨年新しい技術を取得した
adapt,適応する,verb,He adapted quickly to the new working environment,彼は新しい作業環境にすぐに適応した
advise,助言する,verb,She advised him on how to improve his presentation skills,彼女はプレゼンテーションスキルの改善方法について助言した
assure,保証する,verb,The manager assured the team that the project was on track,マネージャーはプロジェクトが順調であるとチームに保証した
clarify,明確にする,verb,Can you clarify the details of the contract?,契約の詳細を明確にしてもらえますか？
collaborate,協力する,verb,We need to collaborate with other departments on this project,このプロジェクトで他の部門と協力する必要がある
compare,比較する,verb,Let's compare the two proposals before making a decision,決定を下す前に2つの提案を比較しよう
compete,競争する,verb,The companies will compete for the top market position,企業は市場のトップポジションを争う
create,創造する,verb,They created a new marketing campaign,彼らは新しいマーケティングキャンペーンを創造した
define,定義する,verb,We need to define the project goals clearly,プロジェクトの目標を明確に定義する必要がある
demonstrate,示す,verb,He demonstrated the features of the new product,彼は新しい製品の機能を示した
design,設計する,verb,The architect designed a modern building,建築家は現代的な建物を設計した
discover,発見する,verb,She discovered a new method for solving the problem,彼女は問題解決の新しい方法を発見した
establish,確立する,verb,The company established a new office in Tokyo,会社は東京に新しいオフィスを確立した
evaluate,評価する,verb,We need to evaluate the performance of the new system,新しいシステムのパフォーマンスを評価する必要がある
expand,拡張する,verb,The business is expanding into international markets,ビジネスは国際市場に拡張している
facilitate,促進する,verb,The new software will facilitate communication between teams,新しいソフトウェアはチーム間のコミュニケーションを促進する
forecast,予測する,verb,We need to forecast sales for the next quarter,次の四半期の売上を予測する必要がある
implement,実施する,verb,The new policy was implemented last month,新しい方針は先月実施された
increase,増加する,verb,The company increased its production capacity,会社は生産能力を増加させた
invest,投資する,verb,They decided to invest in new technology,彼らは新しい技術に投資することを決定した
manage,管理する,verb,He manages a team of engineers,彼はエンジニアのチームを管理している
negotiate,交渉する,verb,They negotiated better terms for the contract,彼らは契約のより良い条件を交渉した
offer,提供する,verb,The company offers a range of services,会社は様々なサービスを提供している
perform,実行する,verb,She performed the experiment successfully,彼女は実験を成功裏に実行した
prioritize,優先順位を付ける,verb,We need to prioritize our tasks,タスクに優先順位を付ける必要がある
produce,生産する,verb,The factory produces high-quality goods,工場は高品質な商品を生産する
promote,促進する,verb,The campaign promoted healthy eating habits,キャンペーンは健康的な食習慣を促進した
provide,提供する,verb,The company provides training for all employees,会社は全社員にトレーニングを提供する
recommend,推奨する,verb,She recommended a new supplier,彼女は新しいサプライヤーを推奨した
reduce,削減する,verb,They reduced costs by improving efficiency,効率を改善することでコストを削減した
refine,洗練する,verb,The team refined the product design,チームは製品デザインを洗練させた
resolve,解決する,verb,We need to resolve this issue quickly,この問題を早急に解決する必要がある
review,見直す,verb,He reviewed the report before the meeting,彼は会議の前にレポートを見直した
support,サポートする,verb,The team supports each other in their work,チームはお互いの仕事をサポートしている
sustain,維持する,verb,The company aims to sustain its growth,会社は成長を維持することを目指している
train,訓練する,verb,The new employees are trained by experienced staff,新しい社員は経験豊富なスタッフによって訓練される
transform,変革する,verb,The company transformed its business model,会社はビジネスモデルを変革した
update,更新する,verb,Please update the software to the latest version,ソフトウェアを最新バージョンに更新してください
utilize,利用する,verb,We need to utilize our resources more effectively,リソースをより効果的に利用する必要がある
validate,検証する,verb,The system validates user input for errors,システムはユーザー入力のエラーを検証する
verify,確認する,verb,He verified the accuracy of the data,彼はデータの正確性を確認した
visualize,視覚化する,verb,We need to visualize the data to understand it better,データを視覚化してよりよく理解する必要がある";
string csv11 = $@"accommodate,対応する,verb,The hotel can accommodate up to 200 guests,ホテルは最大200人のゲストに対応できる
achieve,達成する,verb,She achieved her sales targets for the year,彼女は年間の売上目標を達成した
allocate,配分する,verb,The budget was allocated for research and development,予算は研究開発に配分された
anticipate,予測する,verb,We anticipate a rise in sales next quarter,次の四半期に売上の増加を予測している
authorize,承認する,verb,The manager authorized the purchase of new equipment,マネージャーは新しい機器の購入を承認した
collaborate,協力する,verb,The two companies collaborated on a new project,2社は新しいプロジェクトで協力した
compensate,補償する,verb,The company compensated employees for overtime work,会社は残業に対して社員に補償を行った
coordinate,調整する,verb,We need to coordinate with the other departments,他の部門と調整する必要がある
demonstrate,実演する,verb,She demonstrated the new software features to the team,彼女はチームに新しいソフトウェアの機能を実演した
estimate,見積もる,verb,We need to estimate the costs of the project,プロジェクトのコストを見積もる必要がある
facilitate,促進する,verb,The new tool will facilitate data analysis,新しいツールはデータ分析を促進する
generate,生成する,verb,The system generates reports automatically,システムはレポートを自動的に生成する
implement,実施する,verb,The team implemented a new workflow process,チームは新しいワークフロープロセスを実施した
improve,改善する,verb,We need to improve customer satisfaction scores,顧客満足度スコアを改善する必要がある
inspire,鼓舞する,verb,The leader inspired the team with her vision,リーダーは彼女のビジョンでチームを鼓舞した
introduce,紹介する,verb,The company introduced a new product line this year,会社は今年新しい製品ラインを紹介した
maintain,維持する,verb,The team maintains high standards of quality,チームは高い品質基準を維持している
monitor,監視する,verb,We need to monitor the system for any issues,システムの問題を監視する必要がある
negotiate,交渉する,verb,They negotiated a lower price for the contract,彼らは契約の価格を交渉して下げた
organize,整理する,verb,She organized the files into a new system,彼女はファイルを新しいシステムに整理した
present,提示する,verb,He presented the findings at the meeting,彼は会議で調査結果を提示した
propose,提案する,verb,The team proposed a new strategy for the project,チームはプロジェクトのために新しい戦略を提案した
regulate,規制する,verb,The government regulates the industry to ensure safety,政府は安全性を確保するために業界を規制している
review,再検討する,verb,We need to review the contract terms,契約条件を再検討する必要がある
schedule,スケジュールする,verb,They scheduled a meeting for next Monday,彼らは次の月曜日に会議をスケジュールした
simplify,簡素化する,verb,The new software simplifies the accounting process,新しいソフトウェアは会計プロセスを簡素化する
sponsor,スポンサーする,verb,The company sponsored the charity event,会社はチャリティイベントのスポンサーをした
suggest,提案する,verb,She suggested some improvements to the design,彼女はデザインのいくつかの改善を提案した
support,支援する,verb,The team supports each other during tough times,チームは困難な時期にお互いを支援する
train,訓練する,verb,They trained new employees on the software,彼らは新しい社員にソフトウェアの訓練を行った
transfer,移動する,verb,He transferred to a new department last month,彼は先月新しい部門に移動した
upgrade,アップグレードする,verb,The system was upgraded to the latest version,システムは最新バージョンにアップグレードされた
validate,検証する,verb,The software validates user credentials,ソフトウェアはユーザーの資格情報を検証する
achieve,達成する,verb,She achieved significant progress in her studies,彼女は学業で大きな進歩を達成した
apply,適用する,verb,You can apply these principles to your work,これらの原則を仕事に適用できます
benefit,利益を得る,verb,The new policies benefit both employees and customers,新しい方針は社員と顧客の両方に利益をもたらす
capitalize,活用する,verb,We need to capitalize on this market opportunity,この市場機会を活用する必要がある
commit,コミットする,verb,He committed to the project for six months,彼はプロジェクトに6ヶ月間コミットした
combine,組み合わせる,verb,They combined their resources to complete the task,彼らはリソースを組み合わせてタスクを完了した
create,創造する,verb,They created a new logo for the company,彼らは会社のために新しいロゴを創造した
delegate,委任する,verb,She delegated tasks to her team members,彼女はチームメンバーにタスクを委任した
engage,関与する,verb,We need to engage with our clients more effectively,クライアントとより効果的に関与する必要がある
enforce,施行する,verb,The regulations are enforced by the government,規制は政府によって施行される
investigate,調査する,verb,The team is investigating the cause of the issue,チームは問題の原因を調査している
notify,通知する,verb,Please notify us of any changes,変更があれば通知してください
optimize,最適化する,verb,The company optimized its supply chain processes,会社はサプライチェーンのプロセスを最適化した
prepare,準備する,verb,We need to prepare a report for the meeting,会議のためにレポートを準備する必要がある
process,処理する,verb,The system processes transactions quickly,システムはトランザクションを迅速に処理する
prioritize,優先順位を付ける,verb,We need to prioritize customer requests,顧客のリクエストに優先順位を付ける必要がある
project,計画する,verb,They projected sales for the next year,彼らは来年の売上を計画した";
string csv12 = $@"accommodate,対応する,verb,The venue can accommodate up to 300 people,会場は最大300人を収容できる
adapt,適応する,verb,She adapted her teaching methods for remote learning,彼女はリモート学習のために教え方を適応させた
allocate,配分する,verb,The budget was allocated to various departments,予算は様々な部門に配分された
anticipate,予測する,verb,We anticipate a decrease in demand during the off-season,オフシーズン中に需要の減少を予測している
authorize,承認する,verb,The supervisor authorized the overtime request,スーパーバイザーは残業の申請を承認した
collaborate,協力する,verb,They collaborated on a research project,彼らは研究プロジェクトで協力した
compensate,補償する,verb,The company compensated employees for their extra hours,会社は追加勤務に対して社員に補償を行った
coordinate,調整する,verb,We need to coordinate the schedule with the client,スケジュールをクライアントと調整する必要がある
demonstrate,示す,verb,She demonstrated how to use the new software,彼女は新しいソフトウェアの使い方を示した
estimate,見積もる,verb,Can you estimate the time needed for this task?,このタスクに必要な時間を見積もってもらえますか？
facilitate,促進する,verb,The workshop will facilitate team-building activities,ワークショップはチームビルディング活動を促進する
generate,生成する,verb,The machine generates electricity for the plant,機械は工場の電力を生成する
implement,実施する,verb,The new policy was implemented last month,新しい方針は先月実施された
improve,改善する,verb,We need to improve our customer service response time,顧客サービスの応答時間を改善する必要がある
inspire,鼓舞する,verb,Her speech inspired everyone in the room,彼女のスピーチは部屋の皆を鼓舞した
introduce,紹介する,verb,The manager introduced a new project at the meeting,マネージャーは会議で新しいプロジェクトを紹介した
maintain,維持する,verb,He maintains a high level of professionalism,彼は高いレベルのプロフェッショナリズムを維持している
monitor,監視する,verb,We need to monitor the network for any irregularities,ネットワークの不規則性を監視する必要がある
negotiate,交渉する,verb,They negotiated the terms of the agreement,彼らは契約の条件を交渉した
organize,整理する,verb,She organized a charity event for the local community,彼女は地域社会のためにチャリティイベントを整理した
present,提示する,verb,He presented the new marketing strategy to the team,彼はチームに新しいマーケティング戦略を提示した
propose,提案する,verb,The team proposed a new approach to the problem,チームは問題への新しいアプローチを提案した
regulate,規制する,verb,The agency regulates the use of hazardous materials,機関は危険な物質の使用を規制している
review,再検討する,verb,We reviewed the financial report carefully,財務報告書を注意深く再検討した
schedule,スケジュールする,verb,They scheduled the project milestones for the next quarter,彼らは次の四半期のプロジェクトマイルストーンをスケジュールした
simplify,簡素化する,verb,The new system simplifies the data entry process,新しいシステムはデータ入力プロセスを簡素化する
sponsor,スポンサーする,verb,The company sponsored a local sports team,会社は地元のスポーツチームのスポンサーをした
suggest,提案する,verb,She suggested a different way to approach the task,彼女はタスクにアプローチする別の方法を提案した
support,支援する,verb,The program supports small businesses with funding,プログラムは資金提供で小規模ビジネスを支援する
train,訓練する,verb,They trained employees on the new software,彼らは新しいソフトウェアについて社員を訓練した
transfer,転送する,verb,He transferred the files to a new server,彼はファイルを新しいサーバーに転送した
upgrade,アップグレードする,verb,The company upgraded its hardware systems,会社はハードウェアシステムをアップグレードした
validate,検証する,verb,The results were validated by a third party,結果は第三者によって検証された
achieve,達成する,verb,She achieved her goal of becoming a team leader,彼女はチームリーダーになるという目標を達成した
apply,適用する,verb,We need to apply the new regulations immediately,新しい規制を直ちに適用する必要がある
benefit,利益を得る,verb,The new policy benefits all employees,新しい方針は全社員に利益をもたらす
capitalize,活用する,verb,The company capitalized on the new market trends,会社は新しい市場トレンドを活用した
commit,コミットする,verb,They committed to improving customer satisfaction,彼らは顧客満足度の向上にコミットした
combine,組み合わせる,verb,We combined our resources for the project,プロジェクトのためにリソースを組み合わせた
create,創造する,verb,The designer created a new user interface,デザイナーは新しいユーザーインターフェースを創造した
delegate,委任する,verb,She delegated tasks to her team members,彼女はチームメンバーにタスクを委任した
engage,関与する,verb,The company engages with customers through social media,会社はソーシャルメディアを通じて顧客と関与している
enforce,施行する,verb,The new laws will be enforced starting next month,新しい法律は来月から施行される
investigate,調査する,verb,The team is investigating the cause of the outage,チームは停電の原因を調査している
notify,通知する,verb,Please notify us of any changes to the schedule,スケジュールの変更があれば通知してください
optimize,最適化する,verb,They optimized the algorithm for better performance,彼らはパフォーマンス向上のためにアルゴリズムを最適化した
prepare,準備する,verb,We need to prepare for the upcoming presentation,次のプレゼンテーションの準備をする必要がある
process,処理する,verb,The system processes data in real-time,システムはデータをリアルタイムで処理する
prioritize,優先順位を付ける,verb,We need to prioritize urgent tasks,緊急なタスクに優先順位を付ける必要がある
project,予測する,verb,The team projected revenue growth for the year,チームは年間の収益成長を予測した";
string csv13 = $@"accommodate,対応する,verb,The venue can accommodate up to 500 guests,会場は最大500人を収容できる
analyze,分析する,verb,We need to analyze the survey results,調査結果を分析する必要がある
assemble,組み立てる,verb,They assembled the product in the factory,彼らは工場で製品を組み立てた
calculate,計算する,verb,She calculated the total cost of the project,彼女はプロジェクトの総コストを計算した
clarify,明確にする,verb,Can you clarify the terms of the agreement?,契約条件を明確にしてもらえますか？
coordinate,調整する,verb,He coordinated the event logistics,彼はイベントの物流を調整した
conclude,結論を出す,verb,We concluded the meeting with a summary,会議を要約で締めくくった
consult,相談する,verb,They consulted with experts before making a decision,彼らは決定を下す前に専門家に相談した
construct,構築する,verb,The team constructed a new data model,チームは新しいデータモデルを構築した
convert,変換する,verb,The software converts files to different formats,ソフトウェアはファイルを異なる形式に変換する
customize,カスタマイズする,verb,You can customize the settings to your preference,設定を自分の好みにカスタマイズできます
designate,指定する,verb,He designated a new project manager,彼は新しいプロジェクトマネージャーを指定した
distribute,配布する,verb,The company distributed flyers to promote the event,会社はイベントを宣伝するためにチラシを配布した
enhance,強化する,verb,The update enhances the app’s performance,アップデートはアプリのパフォーマンスを強化する
evaluate,評価する,verb,We need to evaluate the effectiveness of the campaign,キャンペーンの効果を評価する必要がある
extract,抽出する,verb,The system extracts data from the database,システムはデータベースからデータを抽出する
facilitate,促進する,verb,The new software facilitates easier communication,新しいソフトウェアはより簡単なコミュニケーションを促進する
forecast,予測する,verb,They forecasted an increase in market demand,彼らは市場の需要の増加を予測した
implement,実施する,verb,The new procedure was implemented last week,新しい手順は先週実施された
initiate,開始する,verb,He initiated the project with a kick-off meeting,彼はキックオフミーティングでプロジェクトを開始した
integrate,統合する,verb,The new system integrates with existing platforms,新しいシステムは既存のプラットフォームと統合されている
interact,相互作用する,verb,The software interacts with various applications,ソフトウェアはさまざまなアプリケーションと相互作用する
launch,開始する,verb,They launched a new marketing campaign,彼らは新しいマーケティングキャンペーンを開始した
manage,管理する,verb,She manages a team of five people,彼女は5人のチームを管理している
negotiate,交渉する,verb,They negotiated the terms of the contract,彼らは契約の条件を交渉した
outline,概説する,verb,He outlined the key points of the project plan,彼はプロジェクト計画の重要なポイントを概説した
perform,実行する,verb,The team performed well under pressure,チームはプレッシャーの中でうまく実行した
prepare,準備する,verb,We need to prepare the documents for the meeting,会議のために書類を準備する必要がある
present,提示する,verb,She presented the findings at the conference,彼女はカンファレンスで調査結果を提示した
process,処理する,verb,The system processes transactions quickly,システムはトランザクションを迅速に処理する
produce,生産する,verb,The factory produces high-quality products,工場は高品質な製品を生産する
review,見直す,verb,We reviewed the proposals from various vendors,さまざまなベンダーからの提案を見直した
specify,指定する,verb,Please specify your requirements in the form,フォームに必要な要件を指定してください
streamline,効率化する,verb,The new process streamlines operations,新しいプロセスは運用を効率化する
submit,提出する,verb,Please submit your report by the end of the day,報告書を今日中に提出してください
succeed,成功する,verb,The project succeeded beyond our expectations,プロジェクトは予想以上の成功を収めた
suspend,一時停止する,verb,The service was suspended for maintenance,サービスはメンテナンスのために一時停止された
synthesize,統合する,verb,They synthesized information from various sources,彼らはさまざまなソースから情報を統合した
test,試験する,verb,We need to test the new software thoroughly,新しいソフトウェアを徹底的に試験する必要がある
update,更新する,verb,He updated the database with new information,彼は新しい情報でデータベースを更新した
validate,検証する,verb,The data was validated by the quality team,データは品質チームによって検証された
adjust,調整する,verb,She adjusted the settings to improve performance,彼女はパフォーマンスを改善するために設定を調整した
automate,自動化する,verb,The process was automated to save time,プロセスは時間を節約するために自動化された
coordinate,調整する,verb,The project manager coordinates with the team regularly,プロジェクトマネージャーは定期的にチームと調整を行う
delegate,委任する,verb,He delegated tasks to his assistant,彼はアシスタントにタスクを委任した
educate,教育する,verb,The company educates employees on new policies,会社は社員に新しい方針について教育する
facilitate,促進する,verb,The new tool facilitates easier data entry,新しいツールはデータ入力をより簡単に促進する
implement,実施する,verb,We implemented a new system last quarter,私たちは先季度に新しいシステムを実施した
instruct,指示する,verb,He instructed the team on how to proceed,彼はチームに進行方法を指示した
introduce,紹介する,verb,They introduced a new feature in the software,彼らはソフトウェアに新しい機能を紹介した";
string csv14 = $@"allocate,配分する,verb,The funds were allocated to various departments,資金は様々な部門に配分された
anticipate,予測する,verb,We anticipate a rise in demand next quarter,次の四半期に需要の増加を予測している
brief,簡潔に説明する,verb,He briefed the team on the project details,彼はプロジェクトの詳細についてチームに簡潔に説明した
compile,編纂する,verb,She compiled a report from the collected data,彼女は収集したデータから報告書を編纂した
consult,相談する,verb,We consulted with the experts before the decision,決定の前に専門家に相談した
contribute,貢献する,verb,Each member contributed to the success of the project,各メンバーがプロジェクトの成功に貢献した
demonstrate,実演する,verb,He demonstrated the use of the new equipment,彼は新しい機器の使い方を実演した
design,設計する,verb,The engineer designed a new prototype,エンジニアは新しいプロトタイプを設計した
discuss,議論する,verb,They discussed the new strategy in detail,彼らは新しい戦略について詳細に議論した
draft,下書きする,verb,She drafted the initial proposal for the project,彼女はプロジェクトの初期提案書を下書きした
establish,確立する,verb,The company established a new office in Singapore,会社はシンガポールに新しいオフィスを確立した
evaluate,評価する,verb,The committee evaluated the candidates' qualifications,委員会は候補者の資格を評価した
expand,拡大する,verb,They plan to expand their business into new markets,彼らは新しい市場へのビジネス拡大を計画している
implement,実施する,verb,The new policy was implemented last week,新しい方針は先週実施された
initiate,開始する,verb,He initiated the project with a kickoff meeting,彼はキックオフミーティングでプロジェクトを開始した
integrate,統合する,verb,The software integrates seamlessly with other tools,ソフトウェアは他のツールとシームレスに統合される
interview,面接する,verb,She interviewed several candidates for the position,彼女はそのポジションのために数人の候補者と面接を行った
launch,開始する,verb,The company launched a new advertising campaign,会社は新しい広告キャンペーンを開始した
manage,管理する,verb,He manages the company's IT department,彼は会社のIT部門を管理している
organize,整理する,verb,They organized a team-building event for the staff,彼らはスタッフのためにチームビルディングイベントを整理した
prepare,準備する,verb,She prepared the presentation for the meeting,彼女は会議のためにプレゼンテーションを準備した
prioritize,優先順位を付ける,verb,We need to prioritize urgent tasks,緊急なタスクに優先順位を付ける必要がある
review,見直す,verb,The supervisor reviewed the project report,スーパーバイザーはプロジェクト報告書を見直した
specify,指定する,verb,Please specify your requirements in the form,フォームに必要な要件を指定してください
structure,構造化する,verb,They structured the report into several sections,彼らは報告書をいくつかのセクションに構造化した
synchronize,同期する,verb,The data is synchronized across all devices,データはすべてのデバイスで同期されている
track,追跡する,verb,We track our progress using various metrics,さまざまな指標を使用して進捗を追跡する
update,更新する,verb,He updated the system with the latest information,彼はシステムを最新の情報で更新した
advise,助言する,verb,She advised the client on investment opportunities,彼女はクライアントに投資の機会について助言した
align,整列させる,verb,We need to align our goals with the company's mission,私たちは目標を会社のミッションに整列させる必要がある
benchmark,基準を設定する,verb,They benchmarked their performance against industry standards,彼らは業界標準に対してパフォーマンスの基準を設定した
clarify,明確にする,verb,The document clarifies the new procedures,文書は新しい手順を明確にする
coordinate,調整する,verb,She coordinated the schedules of all team members,彼女はすべてのチームメンバーのスケジュールを調整した
demonstrate,示す,verb,He demonstrated the new product features,彼は新しい製品の機能を示した
facilitate,促進する,verb,The meeting will facilitate better communication,会議はより良いコミュニケーションを促進する
incorporate,組み入れる,verb,They incorporated feedback into the final design,彼らは最終設計にフィードバックを組み入れた
invest,投資する,verb,The company invested in new technologies,会社は新しい技術に投資した
negotiate,交渉する,verb,She negotiated the terms of the agreement,彼女は契約の条件を交渉した
propose,提案する,verb,They proposed a new method for data analysis,彼らはデータ分析の新しい方法を提案した
research,調査する,verb,He researched the market trends for the report,彼は報告書のために市場のトレンドを調査した
strategize,戦略を立てる,verb,The team strategized for the upcoming quarter,チームは次の四半期に向けて戦略を立てた
validate,検証する,verb,The results were validated by the research team,結果は研究チームによって検証された
align,整列させる,verb,The project aligns with the company's goals,プロジェクトは会社の目標に整列している
build,構築する,verb,They built a new data center last year,彼らは昨年新しいデータセンターを構築した
connect,接続する,verb,The software connects to multiple databases,ソフトウェアは複数のデータベースに接続する
define,定義する,verb,They defined the project scope at the meeting,彼らは会議でプロジェクトの範囲を定義した
demonstrate,実演する,verb,The instructor demonstrated the correct technique,インストラクターは正しい技術を実演した
enhance,強化する,verb,The upgrade enhances the system’s capabilities,アップグレードはシステムの機能を強化する
formulate,策定する,verb,They formulated a plan for the next phase,彼らは次の段階の計画を策定した
implement,実施する,verb,The company implemented new software solutions,会社は新しいソフトウェアソリューションを実施した
investigate,調査する,verb,The team investigated the root cause of the issue,チームは問題の根本原因を調査した
maintain,維持する,verb,He maintains the equipment in good condition,彼は設備を良好な状態に維持している
modify,変更する,verb,They modified the software to improve usability,彼らは使いやすさを改善するためにソフトウェアを変更した
propose,提案する,verb,She proposed several solutions to the problem,彼女はいくつかの解決策を問題に提案した
review,見直す,verb,The committee reviewed the proposals thoroughly,委員会は提案を徹底的に見直した
train,訓練する,verb,They trained staff on new safety procedures,彼らは新しい安全手順についてスタッフを訓練した
update,更新する,verb,He updated the software to the latest version,彼はソフトウェアを最新バージョンに更新した";
string csv15 = $@"achieve,達成する,verb,She achieved her goal of improving her English skills,彼女は英語スキルを向上させる目標を達成した
adjust,調整する,verb,You need to adjust the settings for better performance,より良いパフォーマンスのために設定を調整する必要がある
analyze,分析する,verb,The team analyzed the data to find trends,チームは傾向を見つけるためにデータを分析した
apply,適用する,verb,He applied the new techniques to the project,彼はプロジェクトに新しい技術を適用した
assess,評価する,verb,They assessed the impact of the new policy,彼らは新しい方針の影響を評価した
calculate,計算する,verb,She calculated the total expenses for the trip,彼女は旅行の総費用を計算した
clarify,明確にする,verb,Please clarify the instructions for the task,タスクの指示を明確にしてください
compare,比較する,verb,We need to compare the results with previous data,結果を以前のデータと比較する必要がある
conduct,実施する,verb,He conducted a survey to gather opinions,彼は意見を集めるために調査を実施した
consider,考慮する,verb,Consider all options before making a decision,決定を下す前にすべての選択肢を考慮してください
create,作成する,verb,They created a new marketing strategy,彼らは新しいマーケティング戦略を作成した
deliver,届ける,verb,The company delivered the products on time,会社は製品を期限通りに届けた
design,設計する,verb,The architect designed a modern office building,建築家は現代的なオフィスビルを設計した
develop,開発する,verb,We developed a new software application,私たちは新しいソフトウェアアプリケーションを開発した
estimate,見積もる,verb,They estimated the cost of the project,彼らはプロジェクトのコストを見積もった
evaluate,評価する,verb,The committee evaluated the proposals thoroughly,委員会は提案を徹底的に評価した
expand,拡大する,verb,The company plans to expand into new markets,会社は新しい市場に拡大する計画を立てている
implement,実施する,verb,The team implemented the new system last month,チームは先月新しいシステムを実施した
improve,改善する,verb,She improved her skills through practice,彼女は練習を通じてスキルを改善した
increase,増加する,verb,They increased the production capacity to meet demand,需要に応えるために生産能力を増加させた
install,インストールする,verb,He installed the software on all computers,彼はすべてのコンピュータにソフトウェアをインストールした
maintain,維持する,verb,The technician maintains the equipment regularly,技術者は定期的に設備を維持する
manage,管理する,verb,She manages the company's financial operations,彼女は会社の財務運営を管理している
modify,変更する,verb,They modified the design based on feedback,彼らはフィードバックに基づいてデザインを変更した
monitor,監視する,verb,We monitor the performance of the system,システムのパフォーマンスを監視する
negotiate,交渉する,verb,He negotiated the terms of the contract,彼は契約の条件を交渉した
organize,整理する,verb,She organized the files into categories,彼女はファイルをカテゴリに整理した
plan,計画する,verb,They planned the project timeline in detail,彼らはプロジェクトのタイムラインを詳細に計画した
prepare,準備する,verb,He prepared the presentation for the meeting,彼は会議のためにプレゼンテーションを準備した
present,提示する,verb,She presented the results to the team,彼女はチームに結果を提示した
prioritize,優先順位を付ける,verb,We need to prioritize the urgent tasks,緊急なタスクに優先順位を付ける必要がある
review,見直す,verb,They reviewed the documents for errors,彼らはエラーのために文書を見直した
schedule,スケジュールする,verb,He scheduled a meeting for next week,彼は来週の会議をスケジュールした
select,選ぶ,verb,She selected the best candidates for the position,彼女はそのポジションのために最良の候補者を選んだ
simplify,簡略化する,verb,The new software simplifies complex tasks,新しいソフトウェアは複雑なタスクを簡略化する
solve,解決する,verb,They solved the problem quickly,彼らは問題を迅速に解決した
submit,提出する,verb,Please submit your report by Friday,金曜日までに報告書を提出してください
track,追跡する,verb,The system tracks inventory levels,システムは在庫レベルを追跡する
update,更新する,verb,She updated the database with new information,彼女はデータベースを新しい情報で更新した
verify,確認する,verb,We need to verify the accuracy of the data,データの正確性を確認する必要がある
allocate,配分する,verb,The budget was allocated for marketing and development,予算はマーケティングと開発に配分された
adapt,適応する,verb,The company adapted to the changing market conditions,会社は変化する市場条件に適応した
compile,編纂する,verb,He compiled a list of potential suppliers,彼は潜在的なサプライヤーのリストを編纂した
distribute,配布する,verb,They distributed the brochures at the event,彼らはイベントでパンフレットを配布した
educate,教育する,verb,The program educates employees on new procedures,プログラムは社員に新しい手順について教育する
implement,実施する,verb,We implemented the new guidelines in the department,私たちは部門で新しいガイドラインを実施した
instruct,指示する,verb,The manager instructed the team on the new protocol,マネージャーはチームに新しいプロトコルについて指示した
interact,相互作用する,verb,The software interacts with various databases,ソフトウェアはさまざまなデータベースと相互作用する";
string csv16 = $@"achieve,達成する,verb,She achieved her goal of improving her English skills,彼女は英語スキルを向上させる目標を達成した
adjust,調整する,verb,You need to adjust the settings for better performance,より良いパフォーマンスのために設定を調整する必要がある
analyze,分析する,verb,The team analyzed the data to find trends,チームは傾向を見つけるためにデータを分析した
apply,適用する,verb,He applied the new techniques to the project,彼はプロジェクトに新しい技術を適用した
assess,評価する,verb,They assessed the impact of the new policy,彼らは新しい方針の影響を評価した
calculate,計算する,verb,She calculated the total expenses for the trip,彼女は旅行の総費用を計算した
clarify,明確にする,verb,Please clarify the instructions for the task,タスクの指示を明確にしてください
compare,比較する,verb,We need to compare the results with previous data,結果を以前のデータと比較する必要がある
conduct,実施する,verb,He conducted a survey to gather opinions,彼は意見を集めるために調査を実施した
consider,考慮する,verb,Consider all options before making a decision,決定を下す前にすべての選択肢を考慮してください
create,作成する,verb,They created a new marketing strategy,彼らは新しいマーケティング戦略を作成した
deliver,届ける,verb,The company delivered the products on time,会社は製品を期限通りに届けた
design,設計する,verb,The architect designed a modern office building,建築家は現代的なオフィスビルを設計した
develop,開発する,verb,We developed a new software application,私たちは新しいソフトウェアアプリケーションを開発した
estimate,見積もる,verb,They estimated the cost of the project,彼らはプロジェクトのコストを見積もった
evaluate,評価する,verb,The committee evaluated the proposals thoroughly,委員会は提案を徹底的に評価した
expand,拡大する,verb,The company plans to expand into new markets,会社は新しい市場に拡大する計画を立てている
implement,実施する,verb,The team implemented the new system last month,チームは先月新しいシステムを実施した
improve,改善する,verb,She improved her skills through practice,彼女は練習を通じてスキルを改善した
increase,増加する,verb,They increased the production capacity to meet demand,需要に応えるために生産能力を増加させた
install,インストールする,verb,He installed the software on all computers,彼はすべてのコンピュータにソフトウェアをインストールした
maintain,維持する,verb,The technician maintains the equipment regularly,技術者は定期的に設備を維持する
manage,管理する,verb,She manages the company's financial operations,彼女は会社の財務運営を管理している
modify,変更する,verb,They modified the design based on feedback,彼らはフィードバックに基づいてデザインを変更した
monitor,監視する,verb,We monitor the performance of the system,システムのパフォーマンスを監視する
negotiate,交渉する,verb,He negotiated the terms of the contract,彼は契約の条件を交渉した
organize,整理する,verb,She organized the files into categories,彼女はファイルをカテゴリに整理した
plan,計画する,verb,They planned the project timeline in detail,彼らはプロジェクトのタイムラインを詳細に計画した
prepare,準備する,verb,He prepared the presentation for the meeting,彼は会議のためにプレゼンテーションを準備した
present,提示する,verb,She presented the results to the team,彼女はチームに結果を提示した
prioritize,優先順位を付ける,verb,We need to prioritize the urgent tasks,緊急なタスクに優先順位を付ける必要がある
review,見直す,verb,They reviewed the documents for errors,彼らはエラーのために文書を見直した
schedule,スケジュールする,verb,He scheduled a meeting for next week,彼は来週の会議をスケジュールした
select,選ぶ,verb,She selected the best candidates for the position,彼女はそのポジションのために最良の候補者を選んだ
simplify,簡略化する,verb,The new software simplifies complex tasks,新しいソフトウェアは複雑なタスクを簡略化する
solve,解決する,verb,They solved the problem quickly,彼らは問題を迅速に解決した
submit,提出する,verb,Please submit your report by Friday,金曜日までに報告書を提出してください
track,追跡する,verb,The system tracks inventory levels,システムは在庫レベルを追跡する
update,更新する,verb,She updated the database with new information,彼女はデータベースを新しい情報で更新した
verify,確認する,verb,We need to verify the accuracy of the data,データの正確性を確認する必要がある
allocate,配分する,verb,The budget was allocated for marketing and development,予算はマーケティングと開発に配分された
adapt,適応する,verb,The company adapted to the changing market conditions,会社は変化する市場条件に適応した
compile,編纂する,verb,He compiled a list of potential suppliers,彼は潜在的なサプライヤーのリストを編纂した
distribute,配布する,verb,They distributed the brochures at the event,彼らはイベントでパンフレットを配布した
educate,教育する,verb,The program educates employees on new procedures,プログラムは社員に新しい手順について教育する
implement,実施する,verb,We implemented the new guidelines in the department,私たちは部門で新しいガイドラインを実施した
instruct,指示する,verb,The manager instructed the team on the new protocol,マネージャーはチームに新しいプロトコルについて指示した
interact,相互作用する,verb,The software interacts with various databases,ソフトウェアはさまざまなデータベースと相互作用する";
// await InsertAsync(csv1);
// await InsertAsync(csv2);
// await InsertAsync(csv3);
// await InsertAsync(csv4);
// await InsertAsync(csv5);
// await InsertAsync(csv6);
// await InsertAsync(csv7);
// await InsertAsync(csv8);
// await InsertAsync(csv9);
// await InsertAsync(csv10);
// await InsertAsync(csv11);
// await InsertAsync(csv12);
// await InsertAsync(csv13);
// await InsertAsync(csv14);
// await InsertAsync(csv15);
// await InsertAsync(csv16);
await DeleteDuplicateAsync();

async Task InsertAsync(string csv)
{
    int count = 1;
    IWordRepository repository = new WordRepository(new FirebaseClientService());
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
        Console.WriteLine("{0} {1}", count++, cols[0]);
    }
}

async Task DeleteDuplicateAsync()
{
    int count = 1;
    IWordRepository repository = new WordRepository(new FirebaseClientService());
    var list = await repository.GetWordListAsync();
    var removeWordIdList = list.GroupBy(a => new { a.Word, a.PartOfSpeech }).Where(a => a.Count() >= 2).Select(a => a.Last().WordId).ToList();
    var _client = new FirebaseClientService().Client;
    foreach (var id in removeWordIdList)
    {
        await _client.Child("words").Child(id.ToString()).DeleteAsync();
        Console.WriteLine("Deleted: {0} {1}", count++, id);
    }
}