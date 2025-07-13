// orderScripts.js

function registerModelSelectHandler(modelSelectId, extrasContainerId) {
    const modelSelect = document.getElementById(modelSelectId);
    if (!modelSelect) return;

    modelSelect.addEventListener('change', function () {
        const modelId = this.value;
        fetch(`/Orders/GetExtrasByModel?modelId=${modelId}`)
            .then(res => res.json())
            .then(data => {
                const container = document.getElementById(extrasContainerId);
                container.innerHTML = '';
                data.forEach(extra => {
                    const div = document.createElement('div');
                    div.className = 'form-check';
                    div.innerHTML = `
                        <input type="checkbox" name="SelectedExtraIds" value="${extra.id}" class="form-check-input" id="extra_${extra.id}" />
                        <label class="form-check-label" for="extra_${extra.id}">${extra.name}</label>
                    `;
                    container.appendChild(div);
                });
            });
    });
}

function registerBrandSelectHandler(brandSelectId, modelSelectId) {
    $(document).ready(function () {
        $(#brandSelectId).change(function () {
            var brandId = $(this).val();
            var modelSelect = $(#modelSelectId);
            modelSelect.empty();

            if (brandId) {
                $.getJSON('/Orders/GetModelsByBrand', { brandId: brandId }, function (data) {
                    modelSelect.append($('<option>').text('-- Select Model --').attr('value', ''));
                    $.each(data, function (i, item) {
                        modelSelect.append($('<option>').attr('value', item.id).text(item.name));
                    });
                });
            } else {
                modelSelect.append($('<option>').text('-- Select Model --').attr('value', ''));
            }
        });
    });
}
