
new Vue({
    el: '#main-App',
    data: {
        text: "",
        fileName: "",
        xmlCheckBox: "",
        csvCheckBox: "",
        notification: "",
    },

    methods: {
        save: function () {
            if (this.checkTxbValue()) {
                if (this.xmlCheckBox == true) {
                    this.postXML();
                }

                if (this.csvCheckBox == true) {
                    this.postCSV();
                }

                if (this.xmlCheckBox == true && this.csvCheckBox == true) {
                    alert("Congratulation your text has been saved as XML and CSV files.")
                    this.clearForm();
                }
                else if (this.xmlCheckBox == true) {
                    alert("Congratulation your text has been saved as XML file.")
                    this.clearForm();
                }
                else if (this.csvCheckBox == true) {
                    alert("Congratulation your text has been saved as CSV file.")
                    this.clearForm();
                }
                else {
                    alert("Please choose one of the output format. ")
                }

            }
            else {
                alert("Please enter TEXT and FILE NAME. ")
            }
        },

        clearForm: function () {
            this.text = "",
            this.fileName = "",
            this.xmlCheckBox = false,
            this.csvCheckBox = false
        },

        checkTxbValue: function () {
            if (this.text != "" && this.fileName != "") {
                return true
            }
            return false
        },

        postXML: function () {
            this.$http.post('../api/xml', {
                Sentences: this.text,
                dirPath: this.fileName
            });
        },

        postCSV: function () {
            this.$http.post('../api/csv', {
                Sentences: this.text,
                dirPath: this.fileName
            });
        }
    }
})

