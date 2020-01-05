<template>
    <div>
        <hot-table :settings="hotSettings" />
    </div>
    
</template>

<script>
    import {HotTable} from "@handsontable/vue";
    
    export default {
        name: "ModelResponseHandsontable",
        components: {
            HotTable
        },
        data() {
            return {
                hotSettings: {
                    // 非商用向けのライセンス
                    licenseKey: 'non-commercial-and-evaluation',
                    
                    // 初期データなし
                    data: [],
                    // Name列だけ、幅を指定する
                    colWidths: [null, 200, null],
                    
                    colHeaders: ["No", "Name", "Age"],
                    rowHeaders: ["1st", "2nd", "3rd"],
                    
                    // コンテキストメニューまわり
                    // contextMenu: true,  // trueにすると、ブラウザのコンテキストメニューが表示されない
                    allowInsertColumn: false,
                    allowRemoveColumn: false,
                    
                    // 列のソートインディケータを表示
                    columnSorting: {
                        indicator: true
                    }
                }
            }
        },
        created: function() {
            // ロードされた時にAPIを呼んで、Handsontableの初期値を取得する
            fetch('/api/model')
                .then(res => { return res.json() })
                .then(data => {
                    this.hotSettings.data = JSON.parse(data);
                })
        },
    }
</script>

<style>
    @import '~handsontable/dist/handsontable.full.css';

    /* 列ヘッダの色を変更する */
    .handsontable thead th .relative {
        background-color: deepskyblue;
    }
</style>