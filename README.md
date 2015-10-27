# 自作3Dアクションゲーム「INF BATTLE」
Unity3Dで作成した自作アクションゲーム「INF BATTLE」
![manual](/image/main_image.png)
ゲームの簡易マニュアルはREDMEの最下部に画像で載せて有ります。

ゲーム内のマニュアルと同様のものです。

(下まで多少長くなっています)



####(現在実行ファイルはデバッグのため非公開）

- 対応プラットフォーム:Windows PC
- 製作期間
    - プログラム:約1ヶ月 
    - 3DモデルやUI制作など:約1ヶ月


- 現在はAndroid OS向けに最適化中

以下主なソースコードの簡単な説明となっています。

以下に示さないソースコードの多くは内容が類似しているが、別ファイルとしているものが多いです。

***

###アクション系
####主にキャラクターの動作に関するもの

[char_move.cs](https://github.com/OgamiP/IB_game_code/blob/master/cs/char_move.cs)

操作キャラクターの動作スクリプト

[char_skill.cs](https://github.com/OgamiP/IB_game_code/blob/master/cs/char_skill.cs)

キャラクターの攻撃（スキル）を管理するスクリプト

[enemy.cs](https://github.com/OgamiP/IB_game_code/blob/master/cs/enemy.cs)

敵の行動スクリプト　移動はプレイヤーをめざし前進し、設定範囲内にプレイヤーがいる場合攻撃へ遷移する

[skill1button.cs](https://github.com/OgamiP/IB_game_code/blob/master/cs/skill1button.cs)

プレイヤーの攻撃スクリプト　UI上のアイコンをクリックすることで攻撃する仕様

また連続して使用することをクールタイムの実装により防いでいる

[camera.cs](https://github.com/OgamiP/IB_game_code/blob/master/cs/camera.cs)

メインカメラ　プレイヤーの背後を一定距離を保ちキープする　特定の入力でカメラ位置反転を実装

[coin_st.cs](https://github.com/OgamiP/IB_game_code/blob/master/cs/coin_st.cs)

ドロップアイテムスクリプト　敵を倒したとき敵より少しずれた座標にドロップアイテムを生成し、プレイヤーめがけ移動

プレイヤーとの衝突を検出したとき、取得処理後自身を破壊す

***
###システム系
####主にゲームのシステムに関するもの

[time_count.cs](https://github.com/OgamiP/IB_game_code/blob/master/cs/time_count.cs)

制限時間のほか、スコア情報を管理するスクリプト

[Kill_Count_script.cs](https://github.com/OgamiP/IB_game_code/blob/master/cs/Kill_Count_script.cs)

敵の討伐数を管理するスクリプト　討伐数表示はスプライトを用い、数値に対応する数字画像を切り替える処理を行っている

[OnmouseOver.cs](https://github.com/OgamiP/IB_game_code/blob/master/cs/OnmouseOver.cs)

マウスオーバーにより説明文を表示するスクリプト

[thunder_light_script.cs](https://github.com/OgamiP/IB_game_code/blob/master/cs/thunder_light_script.cs)

雷により画面が一瞬明るくなることを環境ライトの明るさ切り替えにより実装（サウンドとの同期は行っていない）


    そのほかのソースコードはcsファイルにまとめてあります。

#簡易マニュアル
![manual](/image/manual.png)

