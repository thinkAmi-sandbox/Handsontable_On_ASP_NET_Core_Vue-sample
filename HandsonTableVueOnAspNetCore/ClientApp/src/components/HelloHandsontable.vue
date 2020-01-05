<template>
    <div>
        <hot-table :settings="hotSettings" />
    </div>
    
</template>

<script>
    import {HotTable} from "@handsontable/vue";
    
    export default {
        name: "HelloHandsontable",
        components: {
            HotTable
        },
        data() {
            return {
                hotSettings: {
                    // 非商用向けのライセンス
                    licenseKey: 'non-commercial-and-evaluation',
                    
                    data: [
                        [1, "紅あずま", 10],
                        [2, "紅はるか", 20],
                        [3, "シルクスイート", 30],
                    ],
                    colHeaders: ["No", "Name", "Price"],
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
        }
    }
</script>

<style>
    @import '~handsontable/dist/handsontable.full.css';

    /* 列ヘッダの色を変更する */
    .handsontable thead th .relative {
        background-color: deepskyblue;
    }
</style>