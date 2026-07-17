window.powerbiInterop = {
    reports: {},

    embedReport: function (elementId, embedConfig, dotnetHelper) {
        const models = window['powerbi-client'].models;
        const embedContainer = document.getElementById(elementId);

        const config = {
            type: 'report',
            tokenType: models.TokenType.Aad,
            permissions: models.Permissions.Read,
            id: embedConfig.reportId,
            embedUrl: embedConfig.embedUrl,
            accessToken: embedConfig.accessToken,
            settings: {
                panes: {
                    filters: { expanded: false, visible: true },
                    pageNavigation: { visible: true },
                    visualizations: { expanded: false, visible: false },
                    fields: { expanded: false, visible: false }
                },
                bars: {
                    actionBar: { visible: true },
                    statusBar: { visible: true }
                }
            }
        };

        window.powerbi.reset(embedContainer);

        const report = window.powerbi.embed(embedContainer, config);
        this.reports[elementId] = report;

        report.off('loaded');
        report.on('loaded', function () {
            dotnetHelper.invokeMethodAsync('OnReportLoaded');
        });

        report.off('rendered');
        report.on('rendered', function () {
            dotnetHelper.invokeMethodAsync('OnReportRendered');
        });

        report.off('error');
        report.on('error', function (event) {
            dotnetHelper.invokeMethodAsync('OnReportError', event.detail.message);
        });
    },

    resetReport: function (elementId) {
        const embedContainer = document.getElementById(elementId);
        if (embedContainer) {
            window.powerbi.reset(embedContainer);
        }
        delete this.reports[elementId];
    }
};